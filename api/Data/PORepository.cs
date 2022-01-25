using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class PORepository : IPORepository
    {

        private DataContext _context;
        private SpecialMaps _special;

        public PORepository(DataContext context, SpecialMaps special)
        {
            _context = context;
            _special = special;
        }

        public Task<int> addPostOp(Class_PostOp p)
        {
            throw new NotImplementedException();
        }
        public Task<PagedList<Class_PostOp>> GetPostOps(ProcedureParams procParams)
        {
            throw new NotImplementedException();
        }
        public async Task<Class_PostOp> GetSpecificPostOp(int id)
        {
            var result = new Class_PostOp();
            if (await _context.PostOps.AnyAsync(u => u.PROCEDURE_ID == id))
            {
                return await _context.PostOps.FirstOrDefaultAsync(u => u.PROCEDURE_ID == id);
            }
            else
            {
                var po = new Class_PostOp();
                po.PROCEDURE_ID = id;
                po.ICU_ARRIVAL_DATE = DateTime.UtcNow;
                po.ICU_DISCHARGE_DATE = po.ICU_ARRIVAL_DATE.AddDays(1);
                po.EXTUBATION_DATE = po.ICU_ARRIVAL_DATE.AddDays(1);
                po.readmitted = "1";
                po.reintubated = "1";

                _context.Add(po);

                if (await SaveAll())
                {

                    return await _context.PostOps.FirstOrDefaultAsync(u => u.PROCEDURE_ID == id);
                }
            }
            return result;
        }
        public async Task<int> updatePostOp(Class_PostOp p)
        {
            _context.Update(p);
            if (await _context.SaveChangesAsync() > 0)
            {
                _context.Update(await updateVLADAsync());
                if (await _context.SaveChangesAsync() > 0) { return 1; }
            }
            return 2;
        }
        private async Task<ClassTableVlad> updateVLADAsync()
        {
            var result = new ClassVlad();
            var ctv = new ClassTableVlad();
            var yas = new List<double>();
            var xas = new List<string>();
            var aantal_results = 0;

            double _log_score = 0;
            double _point_log_score = 0;
            double _cum_log_score = 0;
            int _dead = 0;

            var procedures = _context.Procedures.AsQueryable();
            procedures = procedures.Where(s => s.SelectedSurgeon == _special.getCurrentUserId()); // filter on the current loggedin surgeon

            foreach (Class_Procedure p in procedures)
            {
                if (await this.IsDischargedAsync(p.ProcedureId)) // filter out patients that are still admitted
                {
                    try // this will fail if the euroscore is not saved and contains the log_score variable
                    {
                        _log_score = await getLogScoreAsync(p.PatientId);
                        _dead = await getDead(p.PatientId);
                        if (_log_score != 0.0)
                        {
                            if (await calculate_bonus_malusAsync(_dead, p.ProcedureId))
                            {
                                _point_log_score = _log_score / 100;
                                _cum_log_score = _cum_log_score + _point_log_score;
                            }
                            else
                            {
                                _point_log_score = (_log_score - 100) / 100;
                                _cum_log_score = _cum_log_score + _point_log_score;
                            };
                            yas.Add(Math.Round(_cum_log_score, 2));
                            xas.Add(aantal_results.ToString());
                            aantal_results = aantal_results + 1;
                        }
                    }
                    catch (Exception e)
                    {
                     Console.WriteLine(e.InnerException);
                    }
                }
            }
            result.caption = "Variable Life Adjusted Display";
            result.dataXas = xas.ToArray();
            result.dataYas = yas.ToArray();

            // now update this to the database, make comma separated string van de arrays
            var records = _context.Vlads.AsQueryable();
            records = records.Where(x => x.current_user_id == _special.getCurrentUserId());
            records = records.Where(x => x.hospitalId == 0);// the 0 means here all the hospitals

            if (records.Count() == 0)
            {// see if there is a record for this vlad
                ctv.caption = "";
                ctv.current_user_id = _special.getCurrentUserId();
                ctv.hospitalId = 0; //all hospitals
                ctv.dataXas = "";
                ctv.dataYas = "";
                _context.Add(ctv);
                if (await SaveAll())
                {
                    ctv.caption = result.caption;
                    ctv.dataXas = string.Join(",", result.dataXas);
                    ctv.dataYas = string.Join(",", result.dataYas);
                }
            }
            else
            {
                foreach (ClassTableVlad c in records)
                {
                    ctv = c;
                    ctv.caption = "Variable Life Adjusted Display (All hospitals)";
                    ctv.dataXas = string.Join(",", result.dataXas);
                    ctv.dataYas = string.Join(",", result.dataYas);
                }
            }
            return ctv;

        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<bool> calculate_bonus_malusAsync(int dead, int Id)
        {
            var help = true;
            if (dead.ToString() == "2")
            {
                if (await IsSurgicalDeathAsync(Id)) { help = false; } else { help = true; }
            };

            return help;
        }
        private async Task<bool> IsDischargedAsync(int Id)
        {
            var help = false;
            var javascriptStart = new DateTime(1970, 01, 01);
            // check and see if this record exists, if not do nothing it will come sometime anyway
            if (await _context.PostOps.AnyAsync(u => u.PROCEDURE_ID == Id))
            {
                var test = await _context.PostOps.FirstOrDefaultAsync(x => x.PROCEDURE_ID == Id);
                if (// this tests if a discharge date is entered
                    (test.DISCHARGE_DATE.Date - javascriptStart.Date).Days > 0 ||
                    (test.mortality_date.Date - javascriptStart.Date).Days > 0
                    ) { help = true; }

            }
            return help;
        }
        private async Task<bool> IsSurgicalDeathAsync(int Id)
        {
            var help = false;
            var selectedProcedure = await _context.Procedures.FirstOrDefaultAsync(x => x.ProcedureId == Id);
            var selectedPostOP = await _context.PostOps.FirstOrDefaultAsync(x => x.PROCEDURE_ID == Id);

            if ((selectedPostOP.DISCHARGE_DATE.Date - selectedProcedure.DateOfSurgery.Date).Days > 30)
            {// discharged after more then 30 days so NO surgical mortality
                if ((selectedPostOP.DISCHARGE_DATE.Date - selectedPostOP.mortality_date).Days == 0) // patient was never dicharged so always surgical death
                { help = true; }
                else
                { help = false; }
            }
            else
            {
                help = true;
            };
            return help;
        }
        private async Task<double> getLogScoreAsync(int patientId)
        {
            double result = 0.0;
            if (await _context.Patients.AnyAsync(u => u.PatientId == patientId))
            {
                var sp = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == patientId);
                var test = sp.log_score; // is iets als 1.34 %
                if (test != "")
                {
                    test = test.Trim(new Char[] { ' ', '%' });
                    result = Convert.ToDouble(test);
                    return result;
                }
            }
            return result;
        }
        private async Task<int> getDead(int patientId)
        {
            int result = 0;
            if (await _context.Patients.AnyAsync(u => u.PatientId == patientId))
            {
                var sp = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == patientId);
                result = sp.dead;
            }
            return result;
        }

    }
}
