using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOA.data.code;
using SOA.data.dtos;
using SOA.data.Interfaces;
using SOA.Models;

namespace SOA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Valved_ConduitController : ControllerBase
    {
       private IValveRepository _valve;
        private SpecialMaps _special;
        public Valved_ConduitController(IValveRepository valve, SpecialMaps special)
        {
            _valve = valve;
            _special = special;
        }


        [HttpGet("valvedConduitsFromProcedure/{id}")]
        public async Task<IActionResult> getValverepairsfromProcedure(int id)
        {
            var p = new List<ValveForReturnDTO>();
            var t = await _valve.getValvedConduitsFromProcedure(id);
            foreach (Class_Valve cv in t)
            {
                p.Add(_special.mapToValveForReturn(cv));
            }
            return Ok(p);
        }
        
        
         // read Valved_Conduit
        [HttpGet("{id}", Name = "GetValvedConduit")]
        public async Task<IActionResult> Get(int id)
        {
            var p = await _valve.GetSpecificValvedConduit(id);
            return Ok(_special.mapToValveForReturn(p));
        }

        //Create Valved_Conduit
        
        [HttpPost("{procedure_id}")]
        public async Task<IActionResult> Post(int procedure_id)
        {
            var x = await _valve.addValvedConduit(procedure_id);
            return Ok(_special.mapToValveForReturn(x));
        }
        //update Valved_Conduit
        [HttpPut]
        public async Task<IActionResult> Put(ValveForReturnDTO v)
        {
            var p = await _valve.GetSpecificValvedConduit(v.Id);
            var x = await _valve.updateValve(_special.mapToClassValve(v, p));
            if (x == 1) { return Ok("Valved_Conduit updated"); }
            return BadRequest("Error updating valvedConduit ...");
        }
        


    }
}