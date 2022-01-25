using System;
using System.Threading.Tasks;
using api.Data.reports.interfaces;
using api.DTOs;
using api.Entities;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
   
    public class PreviewReportController : BaseApiController
    {

        private IPV _repo;
        private IUserRepository _ur;
        private IHospitalRepository _hos;
        private IProcedureRepository _proc;
        private SpecialMaps _sm;
        private SpecialReportMaps _sprm;

        public PreviewReportController(IPV repo,
            IUserRepository ur,
            IHospitalRepository hos,
            SpecialMaps sm,
            SpecialReportMaps sprm,
            IProcedureRepository proc)
        {
            _repo = repo;
            _sm = sm;
            _proc = proc;
            _ur = ur;
            _hos = hos;
            _sprm = sprm;

        }

        [HttpGet("{id}", Name = "GetPreview")]
        public async Task<IActionResult> Get(int id) { return Ok(await _repo.getPreViewAsync(id)); }

        [HttpGet("reset/{id}", Name = "ResetView")]
        public async Task<IActionResult> Reset(int id) { return Ok(await _repo.resetPreViewAsync(id)); }

        [HttpPost]
        public async Task<IActionResult> Post(PreviewForReturnDTO pvfr)
        {
            try
            {
                Class_privacy_model pm = _sprm.mapToClassPrivacyModel(pvfr);
                Class_Preview_Operative_report pv = await _repo.getPreViewAsync(pvfr.procedure_id);
                pv = _sprm.mapToClassPreviewOperativeReport(pvfr,pv);

                // save the Class_Preview_Operative_report to the database first
                var result = await _repo.updatePVR(pv);

                // generate final operative report and save to database, all done in _sprm;
                var fop = await _sprm.updateFinalReportAsync(pm, pv.procedure_id);

                return Ok(result);
            }
            catch (Exception e) {Console.WriteLine(e.InnerException); }
            return BadRequest("Error saving the preview report");

        }
    }
}