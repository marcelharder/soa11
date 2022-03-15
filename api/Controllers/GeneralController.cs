using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.DTOs;
using api.Helpers;
using api.Interfaces;
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
        [Route("patient_in_database/{id}")]
        public async Task<ActionResult> GetIDB(string id)
        {
            var p = await _rep.GetPatientInDatabase(id);
            return Ok(p);
        }

       
        [HttpGet]
        [AllowAnonymous]
        [Route("proceduresFromPatientId/{id}")]
         public async Task<IActionResult> getiets(int id) {
             var result = await _proc.getProceduresFromPatientId(id);
             return Ok(result);
         }

        [HttpGet]
        [AllowAnonymous]
        [Route("proceduresFromMRN/{mrn}")]
         public async Task<IActionResult> getietsr(string mrn) {
             var result = await _proc.getProceduresFromMRN(mrn);
             return Ok(result);
         }

        [HttpGet]
        [AllowAnonymous]
        [Route("isComplete/{id}")]
        public async Task<ActionResult> GetComplete(int id)
        {
            var p = await _sp.IsThisProcedureComplete(id);
            return Ok(p);
        }
        #region <!-- Cabg stuff -->

        [HttpGet]
        [AllowAnonymous]
        [Route("showVSM/{id}")]
        public async Task<ActionResult> GetVSM(int id)
        {
            return Ok(await _cabg.showVSMHarvestAsync(id));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("showRadial/{id}")]
        public async Task<ActionResult> GetRadial(int id)
        {
            return Ok(await _cabg.showRadialHarvestAsync(id));
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("showTachtig/{id}")]
        public async Task<ActionResult> Get80(int id)
        {
            return Ok(await _cabg.show80Async(id));
        }
#endregion

        [HttpGet]
        [AllowAnonymous]
        [Route("loadReportCode/{id}")]
        public IActionResult GetRC(int id)
        {// get the correct report code for this procedure type, used in preview reports
            var result = _sprm.getReportCode(id);
            return Ok(result);
        }

        #region <!-- email stuff -->
        [HttpPost]
        [AllowAnonymous]
        [Route("sendEmail")]
        public async Task<IActionResult> postEmailAsync(EmailDTO em)
        {
            var comaddress = _com.Value.emailURL;
            string result = "";
            var jsonString = JsonSerializer.Serialize(em);
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
        #region <!-- SMS stuff -->
        [HttpPost]
        [AllowAnonymous]
        [Route("sendSMS")]
        public async Task<IActionResult> postSMSAsync(smsDTO em)
        {
            var comaddress = _com.Value.smsURL;
            string result = "";
            var jsonString = JsonSerializer.Serialize(em);
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
        [Route("products/{type}/{position}")]
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
        [Route("ppm")]
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
        [Route("productByValveTypeId/{id}")]
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
        [Route("getValveCodeSizes/{id}")]
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

             

    }
}