using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace api.Controllers
{

    
    public class GeneralController : BaseApiController
    {
        IUserRepository _repo;
        private IPatientRepository _rep;
        private IValveRepository _valve;
        private IProcedureRepository _proc;
        private IHospitalRepository _hos;
        SpecialMaps _sp;
        private readonly IOptions<ComSettings> _com;

        SpecialReportMaps _sprm;

        private ICABGRepository _cabg;
        public GeneralController(IUserRepository user,
            SpecialMaps sp,
            IOptions<ComSettings> com,
            SpecialReportMaps sprm,
            IValveRepository valve,
            IProcedureRepository proc,
            ICABGRepository cabg,
            IPatientRepository rep,
            IHospitalRepository hos)
        {
            _repo = user;
            _com = com;
            _sp = sp;
            _sprm = sprm;
            _rep = rep;
            _proc = proc;
            _hos = hos;
            _cabg = cabg;
            _valve = valve;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/patient_in_database/{id}")]
        public async Task<ActionResult> GetIDB(string id)
        {
            var p = await _rep.GetPatientInDatabase(id);
            return Ok(p);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/patientFromProcedureId/{id}")]
        public async Task<ActionResult> GetFromProc(int id)
        {
            var p = await _rep.GetPatientFromProcedureId(id);
            return Ok(p);
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/proceduresFromPatientId/{mrn}")]
         public async Task<IActionResult> getiets(string mrn) {
             var result = await _proc.getProceduresFromPatientId(mrn);
             return Ok(result);
         }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/isComplete/{id}")]
        public async Task<ActionResult> GetComplete(int id)
        {
            var p = await _sp.IsThisProcedureComplete(id);
            return Ok(p);
        }
        #region <!-- Cabg stuff -->

        [HttpGet]
        [AllowAnonymous]
        [Route("api/showVSM/{id}")]
        public async Task<ActionResult> GetVSM(int id)
        {
            return Ok(await _cabg.showVSMHarvestAsync(id));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/showRadial/{id}")]
        public async Task<ActionResult> GetRadial(int id)
        {
            return Ok(await _cabg.showRadialHarvestAsync(id));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("api/showTachtig/{id}")]
        public async Task<ActionResult> Get80(int id)
        {
            return Ok(await _cabg.show80Async(id));
        }
#endregion

        [HttpGet]
        [AllowAnonymous]
        [Route("api/loadReportCode/{id}")]
        public IActionResult GetRC(int id)
        {// get the correct report code for this procedure type, used in preview reports
            var result = _sprm.getReportCode(id);
            return Ok(result);
        }

        #region <!-- email stuff -->
        [HttpPost]
        [AllowAnonymous]
        [Route("api/sendEmail")]
        public async Task<IActionResult> postEmailAsync(EmailDTO em)
        {
            var comaddress = _com.Value.emailURL;
            string result = "";
            var jsonString = JsonConvert.SerializeObject(em);
            var payLoad = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(comaddress, payLoad))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(result);
        }
#endregion

        #region <!-- valve stuff -->
      
        [HttpGet]
        [AllowAnonymous]
        [Route("api/products/{type}/{position}")]
        public async Task<IActionResult> getValveById(string type, string position)
        {
            var result = "";
            var comaddress = _com.Value.valveURL;
            var st = "products/" + type + '/' + position;
            comaddress = comaddress + st;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(result);
        }
      
        [HttpGet]
        [AllowAnonymous]
        [Route("api/ppm")]
        public async Task<IActionResult> getPPM([FromQuery] ValveParams vp)
        {
           var result = "";
           var comaddress = _com.Value.valveURL;
           var st = "ppm?" + "productCode=" + vp.productCode + '&' + "size=" + vp.size + '&' + "weight=" + vp.weight + '&' + "height=" + vp.height;
           comaddress = comaddress + st;
          
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/productByValveTypeId/{id}")]
        public async Task<IActionResult> getVVID(int id){
            var result = "";
            var comaddress = _com.Value.valveURL;
            var st = "productByValveTypeId/" + id;
            comaddress = comaddress + st;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(result);
         }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/getValveCodeSizes/{id}")]
        public async Task<IActionResult> getCS(int id)
        {
           var result = "";
           var comaddress = _com.Value.valveURL;
           var st = "getValveCodeSizes/" + id;
           comaddress = comaddress + st;
           using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(comaddress))
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return Ok(result);
        }

#endregion

        /*  [HttpGet]
         [AllowAnonymous]
         [Route("api/loadHospitals/{id}")]
         public  async Task<IActionResult> Get(int id) // get the hospitals where this surgeon worked
         {
             var result = new List<string>();
             var userFromRepo = _repo.GetUser(id);
             var hospitalString = userFromRepo.Result.worked_in; // bv. "12,34,6"
             List<int> help = hospitalString.Split(',').Select(s=>int.Parse(s)).ToList(); // now I have a list of integers
             foreach(int x in help){
                 var h = await _sp.getHospital(x);
                 result.Add(h.HospitalName);}
             return Ok(result);
         }

          // get all hospitals this surgeon worked in
         [HttpGet("api/hospital_worked_in/{id}")]
         [AllowAnonymous]
         public IActionResult GetHospitalsThisSurgeonWorkedIn(int id){
             var result = _hos.GetAllHospitalsThisSurgeonWorkedIn(id);
             return Ok(result);
         }

         [HttpGet]
         [AllowAnonymous]
         [Route("api/loadButtonActions/{id}")]
         public IActionResult GetButtons(int id){
             var result = _sp.getButtonsActions(id);
             return Ok(result);
         }

         [HttpGet]
         [AllowAnonymous]
         [Route("api/loadReportCode/{id}")]
         public IActionResult GetRC(int id){// get the correct report code for this procedure type, used in preview reports
             var result = _sp.getReportCode(id);
             return Ok(result);
         }

         [HttpGet]
         [AllowAnonymous]
         [Route("api/patientFromMRN/{id}")]
         public async Task<ActionResult> GetMRN(string id)
         { 
             var p = await _rep.GetPatientFromMRN(id);
             return Ok(p);
         }



         [HttpGet("api/cabgDescriptions/{id}")]
         [AllowAnonymous]
         public async Task<Class_CABG> Gettest01Async(int id)
         {
             var selectedCABG = await _cabg.GetSpecificCABG(id);
             return await _sp.translateToDescriptions(selectedCABG);
         }

         [HttpGet("api/valveDescriptionFromModel/{model}.{format}"), FormatFilter]
         [AllowAnonymous]
         public async Task<IActionResult> Gettest02Async(string model)
         {
             var result = await _valve.getValveDescriptionFromModel(model);
             return Ok(result);
         }

         [Route("api/procedureIdFromPatientId/{patientId}/{userId}")]
         public async Task<IActionResult> getiets(int patientId, int userId) {
             if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) return Unauthorized();
             var result = await _proc.getProcedureIdFromPatientId(patientId, userId);
             return Ok(result);
         }

         [Route("api/operatedElseWhere/{patientId}/{userId}")]
         public async Task<IActionResult> getookiets(int patientId, int userId) {
             var result = await _proc.getOperatedElseWhere(patientId, userId);
             return Ok(result);
         } */

    }
}