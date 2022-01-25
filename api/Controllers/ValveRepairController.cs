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
    public class ValveRepairController : ControllerBase
    {

        private IValveRepository _valve;
        private SpecialMaps _special;
        public ValveRepairController(IValveRepository valve, SpecialMaps special)
        {
            _valve = valve;
            _special = special;
        }

        [HttpGet("valveRepairsFromProcedure/{id}")]
        public async Task<IActionResult> getValverepairsfromProcedure(int id)
        {
            var p = new List<ValveForReturnDTO>();
            var t = await _valve.getValveRepairsFromProcedure(id);
            foreach (Class_Valve cv in t)
            {
                p.Add(_special.mapToValveForReturn(cv));
            }
            return Ok(p);
        }
         // read
        [HttpGet("{id}/{procedure_id}", Name = "GetValveRepair")]
        public async Task<IActionResult> Get(int id, int procedure_id)
        {
            var p = await _valve.GetSpecificValveRepair(id, procedure_id);
            return Ok(_special.mapToValveForReturn(p));
        }
        //create
        [HttpPost("{position}/{procedure_id}")]
        public async Task<IActionResult> Post(string position,int procedure_id)
        {
            var x = await _valve.addValveRepair(position,procedure_id);
            return Ok(_special.mapToValveForReturn(x));
        }
        //update
        [HttpPut]
        public async Task<IActionResult> Put(ValveForReturnDTO v)
        {
            var p = await _valve.GetSpecificValveRepair(v.Id, v.procedure_id);
            var x = await _valve.updateValve(_special.mapToClassValve(v, p));
            if (x == 1) { return Ok("ValveRepair updated"); }
            return BadRequest("Error updating valve ...");
        }
        // delete
        

    }

}