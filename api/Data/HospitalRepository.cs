using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class HospitalRepository : IHospitalRepository
    {
        private UserManager<AppUser> _manager;
        private DataContext _context;
        private IHttpContextAccessor _http;
        private IWebHostEnvironment _env;
        private SpecialMaps _sm;
      

        public HospitalRepository(
            DataContext context,
            UserManager<AppUser> manager,
            SpecialMaps sm, 
            IHttpContextAccessor http, 
            IWebHostEnvironment env)
        {
            _manager = manager;
            _context = context;
            _env = env;
            _http = http;
            _sm = sm;
        }

        public async Task<int> addHospital(Class_Hospital p)
        {
            var result = _context.Hospitals.Add(p);
            if (await SaveAll()) { return p.hospitalId; } else { return 99; };
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Deleted;
            if (await SaveAll()) { return 1; } else { return 0; }
        }

        public List<Class_Item> GetAllCities()
        {
            HashSet<string> myHashSet = new HashSet<string>();// used to prevent duplicates
            var lis = new List<Class_Item>();
            var listOfHospitals = GetAllHospitals();
            foreach(HospitalForReturnDTO item in listOfHospitals){
                var help = new Class_Item();
                help.value = item.id;
                help.description = item.city;
                if (myHashSet.Add(item.city))// used to prevent duplicates, returns false if the item exists
                { lis.Add(help); }
            }
            return lis;
        }

        public List<Class_Item> GetAllCitiesPerCountry(int id)
        {
            var lis = new List<Class_Item>();
            Class_Item dr;
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country")
                                         where d.Element("ID").Value == id.ToString()
                                         select d;

            foreach (XElement country in help) {

                 IEnumerable<XElement> cities = from d in country.Descendants("cities").Elements("items") select d;
                    foreach(XElement city in cities){
                    dr = new Class_Item();
                    dr.description = city.Element("description").Value; 
                    dr.value = Convert.ToInt32(city.Element("value").Value);
                    lis.Add(dr); 
                    }
            }
            return lis;
        }

        public List<Class_Item> GetAllCountries()
        {
            var lis = new List<Class_Item>();
            Class_Item dr;
            var contentRoot = _env.ContentRootPath;
            var filename = Path.Combine(contentRoot, "conf/countries.xml");
            XDocument order = XDocument.Load(filename);
            IEnumerable<XElement> help = from d in order.Descendants("Country") select d;
            foreach (XElement x in help) {
                 dr = new Class_Item();
                 dr.description = x.Element("Description").Value; 
                 dr.value = Convert.ToInt32(x.Element("ID").Value);
                 lis.Add(dr); 
            }
            return lis;
        }

        public List<HospitalForReturnDTO> GetAllHospitals()
        {
            var hospitals = new List<HospitalForReturnDTO>();
            var result = _context.Hospitals.ToList();
            foreach (Class_Hospital x in result) { hospitals.Add(_sm.mapToHospitalForReturn(x)); }
            return hospitals;
        }

        public List<HospitalForReturnDTO> GetAllHospitalsThisSurgeonWorkedIn(int id)
        {
            var currentUser = _manager.Users.FirstOrDefault(x => x.Id == id);
            string[] hospitalIds = currentUser.worked_in.Split(new string[] { "," }, StringSplitOptions.None);
            var list = new List<HospitalForReturnDTO>();
            foreach (string t in hospitalIds) { list.Add(this.GetSpecificHospital(t.makeSureTwoChar())); };
            return list;
        }

        public async Task<Class_Hospital> getClassHospital(string id)
        {
            var result = await _context.Hospitals.Where(a => a.HospitalNo == id.makeSureTwoChar()).FirstOrDefaultAsync();
            return result;
        }

        public HospitalForReturnDTO GetSpecificHospital(string id)
        {
            var result = _context.Hospitals.Where(a => a.HospitalNo == id.makeSureTwoChar()).FirstOrDefault();
            return _sm.mapToHospitalForReturn(result);
        }

        public async Task<bool> SaveAll() { return await _context.SaveChangesAsync() > 0; }

        public async Task<int> updateHospital(Class_Hospital p)
        {
            var result = _context.Hospitals.Update(p);
            if (await SaveAll()) { return 1; } else { return 99; };
        }
    }
}