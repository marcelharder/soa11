using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Entities;
using api.DTOs;
using Microsoft.AspNetCore.Identity;

namespace api.Helpers
{

    public class SpecialMaps
    {
        private IHttpContextAccessor _http;
        private IMapper _map;

        private UserManager<AppUser> _userManager;
        private DataContext _context;
        private IWebHostEnvironment _env;
        public SpecialMaps(IHttpContextAccessor http,
        UserManager<AppUser> userManager, 
        IMapper map, 
        IWebHostEnvironment env, 
        DataContext context)
        {
            _http = http;
            _map = map;
            _env = env;
            _context = context;
            _userManager = userManager;
        }
        #region <!-- aorticsurgery -->
        public AoSurgeryForReturnDTO mapToAOSForReturn(Class_Aortic_Surgery p) { return _map.Map<Class_Aortic_Surgery, AoSurgeryForReturnDTO>(p); }
        public Class_Aortic_Surgery mapToCAS(AoSurgeryForReturnDTO p, Class_Aortic_Surgery help)
        {
            return _map.Map<AoSurgeryForReturnDTO, Class_Aortic_Surgery>(p, help);
        }
        #endregion

        #region <!-- ltx -->
        public LtxForReturnDTO mapToLTXForReturn(Class_LTX p) { return _map.Map<Class_LTX, LtxForReturnDTO>(p); }
        public Class_LTX mapToLTX(LtxForReturnDTO p, Class_LTX help) { return _map.Map<LtxForReturnDTO, Class_LTX>(p, help); }
        #endregion


        #region <!-- mininv -->
        public MinInvForReturn mapToMinvForReturn(Class_minInv p) { return _map.Map<Class_minInv, MinInvForReturn>(p); }
        public Class_minInv mapFromMinvForReturn(MinInvForReturn c, Class_minInv help)
        {
            return _map.Map<MinInvForReturn, Class_minInv>(c, help);
        }
        #endregion
        #region <!-- patient -->
        public PatientForReturnDTO mapToPatientForReturn(Class_Patient p) { return _map.Map<Class_Patient, PatientForReturnDTO>(p); }
        public Class_Patient mapFromPatientDTOToPatient(FullPatientDTO p, Class_Patient cp) { return _map.Map<FullPatientDTO, Class_Patient>(p, cp); }
        public FullPatientDTO mapToFullPatientDto(Class_Patient test) { return _map.Map<Class_Patient, FullPatientDTO>(test); }
        #endregion
        #region <!-- suggestion -->
        public Class_Suggestion mapToSuggestionFromPreview(Class_Suggestion help, Class_Preview_Operative_report c, int soort)
        {

            help.regel_1_a = c.regel_1;
            help.regel_2_a = c.regel_2;
            help.regel_3_a = c.regel_3;
            help.regel_4_a = c.regel_4;
            help.regel_5_a = c.regel_5;
            help.regel_6_a = c.regel_6;
            help.regel_7_a = c.regel_7;
            help.regel_8_a = c.regel_8;
            help.regel_9_a = c.regel_9;
            help.regel_10_a = c.regel_10;
            help.regel_11_a = c.regel_11;
            help.regel_12_a = c.regel_12;
            help.regel_13_a = c.regel_13;
            help.regel_14_a = c.regel_14;
            help.regel_15 = c.regel_15;
            help.regel_16 = c.regel_16;
            help.regel_17 = c.regel_17;
            help.regel_18 = c.regel_18;
            help.regel_19 = c.regel_19;
            help.regel_20 = c.regel_20;
            help.regel_21 = c.regel_21;
            help.regel_22 = c.regel_22;
            help.regel_23 = c.regel_23;
            help.regel_24 = c.regel_24;
            help.regel_25 = c.regel_25;
            help.regel_26 = c.regel_26;
            help.regel_27 = c.regel_27;
            help.regel_28 = c.regel_28;
            help.regel_29 = c.regel_29;
            help.regel_30 = c.regel_30;
            help.regel_31 = c.regel_31;
            help.regel_32 = c.regel_32;
            help.regel_33 = c.regel_33;

            help.regel_1_b = ""; help.regel_1_c = "";
            help.regel_2_b = ""; help.regel_2_c = "";
            help.regel_3_b = ""; help.regel_3_c = "";
            help.regel_4_b = ""; help.regel_4_c = "";
            help.regel_5_b = ""; help.regel_5_c = "";
            help.regel_6_b = ""; help.regel_6_c = "";
            help.regel_7_b = ""; help.regel_7_c = "";
            help.regel_8_b = ""; help.regel_8_c = "";
            help.regel_9_b = ""; help.regel_9_c = "";
            help.regel_10_b = ""; help.regel_10_c = "";
            help.regel_11_b = ""; help.regel_11_c = "";
            help.regel_12_b = ""; help.regel_12_c = "";
            help.regel_13_b = ""; help.regel_13_c = "";
            help.regel_14_b = ""; help.regel_14_c = "";

            return help;
        }

        public EpaDetailsDto mapToEpaDetailsDto(Class_Epa help)
        {
            var h = new EpaDetailsDto();
            h = _map.Map<Class_Epa,EpaDetailsDto>(help);
            return h;
        }
        #endregion
        #region <!-- user -->
        public UserForReturnDto mapToUserForReturn(AppUser help)
        {
            var h = new UserForReturnDto();
            h = _map.Map<AppUser, UserForReturnDto>(help);
            return h;
        }
        public AppUser mapToUser(UserForUpdateDto help, AppUser h)
        {
            h = _map.Map<UserForUpdateDto, AppUser>(help, h);
            //h.Country = getCountryFromCode(help.country);
            return h;
        }
        #endregion
        #region <!-- employee -->
        public EmployeeForReturnDTO mapToEmployeeForReturn(Class_Employee p)
        {
            return _map.Map<Class_Employee, EmployeeForReturnDTO>(p);
        }
        public Class_Employee mapToEmployeefromEmployeeForUpdate(Class_Employee ce, EmployeeForUpdateDTO eup)
        {
            ce = _map.Map<EmployeeForUpdateDTO, Class_Employee>(eup, ce);
            return ce;
        }



        #endregion
        #region <!-- refPhys -->
        public Class_Ref_Phys mapToRefRhys(refphysForUpdate cr, Class_Ref_Phys old)
        {
            return _map.Map<refphysForUpdate, Class_Ref_Phys>(cr, old);
        }

        public refphysForReturn mapToRefRhysForReturn(Class_Ref_Phys p)
        {
            return _map.Map<Class_Ref_Phys, refphysForReturn>(p);
        }

        #endregion
         #region <!-- eps -->
        public Class_Epa mapToEpa(EpaDetailsDto cr, Class_Epa old)
        {
            return _map.Map<EpaDetailsDto, Class_Epa>(cr, old);
        }

        public EpaDetailsDto mapToepadto(Class_Epa p)
        {
            return _map.Map<Class_Epa, EpaDetailsDto>(p);
        }

        #endregion
         #region <!-- aioCourse -->
        public Class_Course mapToCourse(CourseDetailsDto cr, Class_Course old)
        {
            return _map.Map<CourseDetailsDto, Class_Course>(cr, old);
        }

        public CourseDetailsDto mapToCoursedto(Class_Course p)
        {
            return _map.Map<Class_Course, CourseDetailsDto>(p);
        }

        #endregion
        #region <!-- discharge -->
        public DischargeForReturnDTO mapToDischargeDTO(FullPatientDTO pat, Class_PostOp po)
        {
            var help = new DischargeForReturnDTO();
            help.patient_id = pat.patientId;
            help.procedure_id = po.PROCEDURE_ID;
            help.dead = pat.dead;
            help.dead_location = po.dead_location;
            help.dead_cause = po.dead_cause;
            help.dead_date = po.mortality_date;
            help.discharged_to = po.sent_to;
            help.discharge_diagnosis = po.discharge_diagnosis;
            help.discharge_activities = po.activities_discharge;
            help.full_description = po.full_description;
            help.discharge_date = po.DISCHARGE_DATE;
            return help;
        }
        public Class_Patient mapFromDischargeForUpdate_1(DischargeForUpdateDTO dto, Class_Patient old)
        {
            old.dead = dto.dead;
            return old;
        }

        public Class_PostOp mapFromDischargeForUpdate_2(DischargeForUpdateDTO dto, Class_PostOp old)
        {
            old.dead_location = dto.dead_location;
            old.dead_cause = dto.dead_cause;
            old.mortality_date = dto.dead_date;
            old.sent_to = dto.discharged_to;
            old.discharge_diagnosis = dto.discharge_diagnosis;
            old.full_description = dto.full_description;
            old.activities_discharge = dto.discharge_activities;
            old.DISCHARGE_DATE = dto.discharge_date;
            return old;
        }
        #endregion
        #region <!-- hospital -->
        public HospitalForReturnDTO mapToHospitalForReturn(Class_Hospital x) { return _map.Map<Class_Hospital, HospitalForReturnDTO>(x); }
        public Class_Hospital mapToHospital(HospitalForReturnDTO x, Class_Hospital h) { h = _map.Map<HospitalForReturnDTO, Class_Hospital>(x, h); return h; }
        #endregion
        #region <!-- procedure -->
        public ProcedureDTO mapToDTOFromClassProcedure(Class_Procedure p) { return _map.Map<Class_Procedure, ProcedureDTO>(p); }
        public Class_Procedure mapToClassProcedureFromDTO(ProcedureDTO up, Class_Procedure h) { h = _map.Map<ProcedureDTO, Class_Procedure>(up, h); return h; }


        public async Task<ProcedureListDTO> mapToProcedureListDTOAsync(Class_Procedure us, int s)
        {
            // the s determines if completed will be checked, in case this is an assistant procedure there is no need to check this
            var n = new ProcedureListDTO();
            n = _map.Map<Class_Procedure, ProcedureListDTO>(us);
            if (s == 1) { n.completed = await this.IsThisProcedureComplete(us.PatientId); }
            else { n.completed = null; }

            return n;
        }


        #endregion
        #region <!-- cpb -->
        public CPBForReturnDTO mapToCPBForReturn(Class_CPB cp) { return _map.Map<Class_CPB, CPBForReturnDTO>(cp); }
        public Class_CPB mapToClassCPB(CPBForReturnDTO cp, Class_CPB cpb) { return _map.Map<CPBForReturnDTO, Class_CPB>(cp, cpb); }
        #endregion
        #region <!-- cabg -->
        public Class_CABG mapToClassCABG(CabgDetailsDTO cp, Class_CABG cabg) { return _map.Map<CabgDetailsDTO, Class_CABG>(cp, cabg); }
        public CabgDetailsDTO mapToCABGForReturn(Class_CABG cp) { return _map.Map<Class_CABG, CabgDetailsDTO>(cp); }
        #endregion
        #region <!-- valve -->
        public ValveForReturnDTO mapToValveForReturn(Class_Valve cp) { return _map.Map<Class_Valve, ValveForReturnDTO>(cp); }

        public valveDTO mapClassValveToDTO(Class_Valve_Code cv) { return _map.Map<Class_Valve_Code, valveDTO>(cv); }

        public Class_Valve mapToClassValve(ValveForReturnDTO valveForReturn, Class_Valve cv)
        {

            return _map.Map<ValveForReturnDTO, Class_Valve>(valveForReturn, cv);
        }
        #endregion
        #region <!-- postop -->
        public Class_PostOp mapToClassPostop(PostOpDetailsDTO cp, Class_PostOp post)
        {
            var result = _map.Map<PostOpDetailsDTO, Class_PostOp>(cp, post);

            var test = new DateTime(
                 cp.ICU_DISCHARGE_DATE.Year,
                 cp.ICU_DISCHARGE_DATE.Month,
                 cp.ICU_DISCHARGE_DATE.Day,
                 cp.ICU_DISCHARGE_DATE_HOURS,
                 cp.ICU_DISCHARGE_DATE_MINUTES, 0);
            result.ICU_DISCHARGE_DATE = test;

            test = new DateTime(
            cp.EXTUBATION_DATE.Year,
            cp.EXTUBATION_DATE.Month,
            cp.EXTUBATION_DATE.Day,
            cp.EXTUBATION_DATE_HOURS,
            cp.EXTUBATION_DATE_MINUTES, 0);
            result.EXTUBATION_DATE = test;
            return result;
        }
        public PostOpDetailsDTO mapToPostOpForReturn(Class_PostOp cp)
        {

            var result = _map.Map<Class_PostOp, PostOpDetailsDTO>(cp);
            result.ICU_ARRIVAL_DATE_HOURS = result.ICU_ARRIVAL_DATE.Hour;
            result.ICU_ARRIVAL_DATE_MINUTES = result.ICU_ARRIVAL_DATE.Minute;

            result.ICU_DISCHARGE_DATE_HOURS = result.ICU_DISCHARGE_DATE.Hour;
            result.ICU_DISCHARGE_DATE_MINUTES = result.ICU_DISCHARGE_DATE.Minute;

            result.EXTUBATION_DATE_HOURS = result.EXTUBATION_DATE.Hour;
            result.EXTUBATION_DATE_MINUTES = result.EXTUBATION_DATE.Minute;

            return result;
        }
        #endregion


        #region <!-- utilities -->

        public double getDoubleFromLogScore(string log_score)
        {
            var help = 0.0;
            if (!String.IsNullOrEmpty(log_score))
            {
                if (log_score != "0")
                {
                    log_score = log_score.Substring(0, 4);
                    help = Convert.ToDouble(log_score);
                }

                return help;
            }
            else { return help; }
        }
        public async Task<string> IsThisProcedureComplete(int id) //  see if the euroscore is completed, which concerns horizontal discharge or not
        {
            if (await _context.Procedures.AnyAsync(x => x.PatientId == id))
            {
                //var reportCode = "";
                var selectedProcedure = await _context.Procedures.FirstOrDefaultAsync(x => x.PatientId == id);
                /* var contentRoot = _env.ContentRootPath;
                var filename = Path.Combine(contentRoot, "data/config/procedure.xml");
                XDocument order = XDocument.Load(filename);
                IEnumerable<XElement> help = from d in order.Descendants("Code")
                                             where d.Element("ID").Value == selectedProcedure.fdType.ToString()
                                             select d;
                foreach (XElement x in help) { reportCode = x.Element("report_code").Value; } */
                var selectedpatient = await _context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);
                if (!this.getEligibleForEuroscoreCalculation(selectedProcedure.fdType)) // there is no need to ask for the log_score, bv rethoracotomy for bleeding
                {
                    return "N/A";
                }
                else
                {
                    if (String.IsNullOrEmpty(selectedpatient.log_score)) { return "No"; }
                    else
                    {
                        if (selectedpatient.dead == 0) // this means no choice is made regarding dead or alive
                        { return "No"; }
                        else { return "Yes"; }
                    }
                }
            }
            else { return "No"; }
        }
        internal string getImplantFromModelAsync(string MODEL)
        {

            // var selectedValve = await _context.ValveCodes.FirstOrDefaultAsync(a => a.code == model);
            // return selectedValve.codeId.ToString();

            var result = "";
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/Valve.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("valve_codes")
                                         where d.Element("UK_Code").Value == MODEL
                                         select d;
            foreach (XElement x in help) { result = x.Element("Valve_id").Value; }
            return result;
        }
        internal int CalculateTotalTime(DateTime utcNow, int selectedStartHr, int selectedStartMin, int selectedStopHr, int selectedStopMin)
        {

            long hourTicks = 36000000000;
            long minTicks = 600000000;

            if (selectedStopHr >= selectedStartHr) // procedure finished on the same day
            {
                long beginSurgery = utcNow.Date.Ticks + (selectedStartHr * hourTicks) + (selectedStartMin * minTicks);
                long endSurgery = utcNow.Date.Ticks + (selectedStopHr * hourTicks) + (selectedStopMin * minTicks);
                return (int)((endSurgery - beginSurgery) / minTicks);
            }
            else
            {
                long beginSurgery = utcNow.Date.Ticks + (selectedStartHr * hourTicks) + (selectedStartMin * minTicks);
                long endSurgery = utcNow.Date.Ticks + (selectedStopHr * hourTicks) + (selectedStopMin * minTicks);
                var hoursToAdd = (24 - selectedStartHr) + selectedStopHr;
                var minToAdd = selectedStartMin - selectedStopMin;
                var tickstoAdd = (hoursToAdd * hourTicks) + (minToAdd * minTicks);
                return (int)(((endSurgery - beginSurgery) + tickstoAdd) / minTicks);
            }

        }
        public int getCurrentUserId()
        {
            var userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Convert.ToInt32(userId);
        }
        public async Task<string> getCurrentHospitalIdAsync()
        {
            var help = "";
            var currentUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == getCurrentUserId());
            help = currentUser.hospital_id.ToString();
            return help;
        }
        public Class_Item mapToEmployeeToClassItem(Class_Employee emp)
        {
            var help = new Class_Item();
            help.value = emp.Id;
            help.description = emp.name;
            return help;
        }
        public Class_Item mapUserToClassItem(AppUser u)
        {
            var help = new Class_Item();
            help.value = u.Id;
            help.description = u.UserName;
            return help;
        }
        public Class_Item mapRefPhysToClassItem(Class_Ref_Phys emp)
        {
            var help = new Class_Item();
            help.value = emp.Id;
            help.description = emp.name;
            return help;
        }
        public List<string> getSoortWithVSM()
        {
            var l = new List<string>();
            l.Add("1"); l.Add("23"); l.Add("26"); l.Add("92"); l.Add("98"); l.Add("97");
            return l;
        }
        internal List<string> getSoortWithRadial()
        {
            var l = new List<string>();
            l.Add("23"); l.Add("24"); l.Add("25"); l.Add("926"); l.Add("95"); l.Add("96"); l.Add("997");
            return l;
        }
        internal List<string> getSoortWith80()
        {
            var l = new List<string>();
            l.Add("80"); l.Add("81"); l.Add("82"); l.Add("83"); l.Add("85"); l.Add("86"); l.Add("871"); l.Add("872");
            return l;
        }
        internal int getCountryCode(string input)
        {
            var result = 0;
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country")
                                         where d.Element("ISO").Value == input
                                         select d;

            foreach (XElement country in help) { result = Convert.ToInt32(country.Element("ID").Value); }
            return result;
        }
        internal string getCountryFromCode(int input)
        {
            var result = "";
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country")
                                         where d.Element("ID").Value == input.ToString()
                                         select d;

            foreach (XElement country in help) { result = country.Element("ISO").Value; }
            return result;
        }
        internal string getCountryNameFromCode(int input)
        {
            var result = "";
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country")
                                         where d.Element("ID").Value == input.ToString()
                                         select d;

            foreach (XElement country in help) { result = country.Element("Description").Value; }
            return result;
        }
        internal string getCountryNameFromISO(string input)
        {
            var result = "";
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country")
                                         where d.Element("ISO").Value == input
                                         select d;

            foreach (XElement country in help) { result = country.Element("Description").Value; }
            return result;
        }

        public bool getEligibleForEuroscoreCalculation(int input)
        {
            var help = false;
            switch (input)
            {
                case 1: help = true; break;
                case 2: help = true; break;
                case 21: help = true; break;
                case 23: help = true; break;
                case 24: help = true; break;
                case 25: help = true; break;
                case 26: help = true; break;

                case 926: help = true; break;
                case 92: help = true; break;
                case 93: help = true; break;
                case 94: help = true; break;
                case 95: help = true; break;
                case 98: help = true; break;
                case 96: help = true; break;
                case 97: help = true; break;
                case 997: help = true; break;

                case 3: help = true; break;
                case 30: help = true; break;
                case 4: help = true; break;
                case 41: help = true; break;
                case 45: help = true; break;
                case 46: help = true; break;

                case 5: help = true; break;
                case 51: help = true; break;
                case 53: help = true; break;
                case 54: help = true; break;
                case 55: help = true; break;

                case 7: help = true; break;
                case 56: help = true; break;
                case 142: help = true; break;
                case 102: help = true; break;
                case 104: help = true; break;
                case 105: help = true; break;
                case 146: help = true; break;
                case 1414: help = true; break;

                case 80: help = true; break;
                case 81: help = true; break;
                case 82: help = true; break;
                case 83: help = true; break;
                case 84: help = true; break;
                case 85: help = true; break;
                case 86: help = true; break;

                case 88: help = true; break;
                case 89: help = true; break;
                case 101: help = true; break;
                case 1412: help = true; break;
                case 145: help = true; break;
                case 1418: help = true; break;

                case 148: help = true; break;
                case 149: help = true; break;
                case 1416: help = true; break;
                case 152: help = true; break;
                
            }


            return help;
        }

        /*   internal string getValveTypeDescription(string input)
         {
             var result = "";

             var contentRoot = _env.ContentRootPath;
             var filename = Path.Combine(contentRoot, "data/config/language_file.xml");
             XDocument order = XDocument.Load(filename);
             IEnumerable<XElement> help = from d in order.Descendants("valve_type").Elements("items")
                                          where d.Element("value").Value == input
                                          select d;
             foreach (XElement v in help) { result = v.Element("description").Value; }
             return result;
         } */

        #endregion
    }



}