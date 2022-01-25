using System.IO;
using System.Threading.Tasks;
using api.Data.reports.interfaces;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
   

    public class FinalOperativeReport : BaseApiController
    {
        private readonly IWebHostEnvironment _env;
        private IProcedureRepository _proc;
        private IComposeFinalReport _fr;
        public FinalOperativeReport(IWebHostEnvironment env, IComposeFinalReport fr, IProcedureRepository proc)
        {
            _env = env;
            _fr = fr;
            _proc = proc;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var help = _fr.deletePDF(id);
            var id_string = id.ToString();

            /* if (await _proc.pdfDoesNotExists(id_string))// als de user alleen de send email clickt en niet de save button
            { 
                await _fr.composeAsync(id); //get the final report and composes a pdf, which is stored in assets/pdf/73764743.pdf
            } */

            await _fr.composeAsync(id); //get the final report and composes a pdf, which is stored in assets/pdf/73764743.pdf
            return File(this.GetStream(id_string), "application/pdf", id_string + ".pdf");

        }

        [AllowAnonymous]
        [HttpGet("getRefReport/{hash}")]
        public async Task<IActionResult> getPdfForRefPhys(string hash)
        {
            var id = await _proc.getProcedureIdFromHash(hash);
            if (id != 0)
            {
                if (await _proc.IsThisReportLessThan3DaysOld(id))
                {
                    var id_string = id.ToString();
                    if (await _proc.pdfDoesNotExists(id_string))
                    { 
                        await _fr.composeAsync(id); //get the final report and composes a pdf, which is stored in bv. assets/pdf/73764743.pdf
                    }
                    return File(this.GetStream(id_string), "application/pdf", id_string + ".pdf");
                }
                else
                {
                    var help = _fr.deletePDF(id);
                    return BadRequest("Your operative report is expired ...");
                }
            }
            else { return BadRequest("Your operative report is not found or expired ..."); }
        }

        private Stream GetStream(string id_string)
        {

            var pathToFile = _env.ContentRootPath + "/assets/pdf/";
            var file_name = pathToFile + id_string + ".pdf";
            var stream = new FileStream(file_name, FileMode.Open, FileAccess.Read);
            stream.Position = 0;
            return stream;

        }


    }
}
