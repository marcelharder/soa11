using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    
    public class ValveController : BaseApiController
    {

        private IValveRepository _valve;
        private SpecialMaps _special;
        public ValveController(IValveRepository valve, SpecialMaps special)
        {
            _valve = valve;
            _special = special;
        }

        #region <!-- manage valves in procedures -->
       
        [HttpGet("valvesFromProcedure/{id}")]
        public async Task<IActionResult> getValvesfromProcedure(int id)
        {
            var p = new List<ValveForReturnDTO>();
            var t = await _valve.getValvesFromProcedure(id);
            foreach (Class_Valve cv in t)
            {
                p.Add(_special.mapToValveForReturn(cv));
            }
            return Ok(p);
        }
        // read
        [HttpGet("{serial}/{procedure_id}", Name = "GetValve")]
        public async Task<IActionResult> Get(string serial, int procedure_id)
        {
            var p = await _valve.GetSpecificValve(serial, procedure_id);
            return Ok(p);
        }
        //create
        [HttpPost("{serial}/{procedure_id}")]
        public async Task<IActionResult> Post(string serial, int procedure_id)
        {
            var x = await _valve.addValve(serial, procedure_id);
            return Ok(_special.mapToValveForReturn(x));
        }
        //update
        [HttpPut("updateProcedureValve")]
        public async Task<IActionResult> Put(ValveForReturnDTO v)
        {
            var p = await _valve.GetSpecificValve(v.SERIAL_IMP, v.procedure_id);

            var x = await _valve.updateValve(_special.mapToClassValve(v,p));
            if (x == 1) { return Ok("Valve updated"); }
            return BadRequest("Error updating valve ...");
        }
        // delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string deleteResult;
            var p = await _valve.deleteSpecificValve(id);
            if (p == 1) { deleteResult = "Successfully removed ..."; } else { deleteResult = "Not removed ..."; }
            return Ok(deleteResult);
        }
        #endregion



        [HttpGet("models/{type}/{position}")]
        public async Task<IActionResult> GetM(string type, string position)
        {
            var result = await _valve.getProductCodesInHospital(type, position);
            return Ok(result);
        }


        #region <!-- manage valves in hospital if OVI is not available -->

        [HttpGet("hospitalValves/{type}/{position}")]
        public async Task<IActionResult> GetMH(string type, string position)
        {
            var result = await _valve.getValvesInHospital(type, position);
            return Ok(result);
        }

        [HttpPost("createhospitalValve")]
        public async Task<IActionResult> GetMHC(valveDTO code)
        {
            var result = await _valve.createValveInHospital(code);
            return Ok(result);
        }

       /*  [HttpGet("readHospitalValve/{code}")]
        public async Task<IActionResult> GetMHR(string code)
        {
            if(code != null){var result = await _valve.readValveInHospital(code);
            return Ok(result);}
            return BadRequest("code undefined");
            
        } */

        [HttpPut("updateHospitalValve")]
        public async Task<IActionResult> GetMHU(valveDTO code)
        {
            var result = await _valve.updateValveInHospital(code);
            return Ok(result);
        }

        [HttpDelete("deleteHospitalValve/{code}")]
        public async Task<IActionResult> GetMHD(int code)
        {
            if(code != 0){var result = await _valve.deleteValveInHospital(code);
            if(result == 1) { return Ok("item deleted ..."); }}
            return BadRequest("item could not be deleted ...");
        }
        #endregion

        [HttpGet("valveDescriptionFromModel/{model}")]
        public async Task<IActionResult> GetD(string model)
        {
            var result = await _valve.getValveDescriptionFromModel(model);
            return Ok(result);
        }

        [HttpGet("valveDescriptionFromType/{m}")]
        public async Task<IActionResult> GetVAsync(string m)
        {
            var result = await _valve.getValveDescriptionFromModel(m);
            return Ok(result);
        } 







    }
}