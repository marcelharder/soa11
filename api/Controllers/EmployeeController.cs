using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace api.Controllers
{

    
    // [Authorize]
    public class EmployeeController : BaseApiController
    {
        private IUserRepository _repo;
        private IEmployeeRepository _emp;
        private IHttpContextAccessor _ht;
        List<Class_Item> _result = new List<Class_Item>();
        OperatieDrops _copd;
        private IUserRepository _user;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        private SpecialMaps _maps;

        public EmployeeController(IUserRepository repo, 
            IUserRepository user, 
            SpecialMaps maps,
            IHttpContextAccessor ht, 
            IEmployeeRepository emp, 
            OperatieDrops copd, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _repo = repo;
            _emp = emp;
            _copd = copd;
            _ht = ht;
            _user = user;
            _maps = maps;

            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

       
        [Route("api/getSpecificEmployee/{id}", Name = "GetEmpById")]
         [HttpGet]
        public async Task<IActionResult> getE(int id) { 
            var result = await _emp.getSpecificEmployee(id); 
            return Ok(_maps.mapToEmployeeForReturn(result)); }

        [HttpPut]
        [Route("api/updateEmployee")]
       public async Task<IActionResult> updateEmployee (EmployeeForUpdateDTO eup)
        {
            var ce = await _emp.getSpecificEmployee(eup.id);
            var result = await _emp.updateEmployee(eup.id, _maps.mapToEmployeefromEmployeeForUpdate(ce, eup));
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/deleteEmployee/{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            var p = await _emp.deleteEmployee(id);
            return Ok(p);
        }

        [HttpGet]
        [Route("api/addEmployee/{profession}")]
        [Authorize]
        public async Task<ActionResult> addEmployee(string profession)
        {
            var employee = await _emp.addEmployee();
            var currentUserId = _ht.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _user.GetUser(Convert.ToInt32(currentUserId));

            employee.profession = profession;
            employee.selected_hospital_id = currentUser.hospital_id.ToString();
            employee.image = "https://res.cloudinary.com/marcelcloud/image/upload/v1559818775/user.png.jpg";
            employee.active = false;
            employee.liscense_to_kill = "0";

            if (await _emp.SaveAll())
            {
                var EmployeeToReturn = _maps.mapToEmployeeForReturn(employee);
                return CreatedAtRoute("GetEmpById", new { id = employee.Id }, EmployeeToReturn);
            }

            return BadRequest("Could not add Employee");
        }

        [HttpPost("api/addEmployeePhoto/{id}")]
        public async Task<IActionResult> AddPhotoForUser(int id, [FromForm]PhotoForCreationDto photoDto)
        {
            // if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value)) return Unauthorized();
            var employee = await _emp.getSpecificEmployee(id);

            var file = photoDto.file;
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
                employee.image = uploadResult.Uri.ToString();

                if (await _emp.SaveAll()) return CreatedAtRoute("GetEmpById", new {id = employee.Id }, employee);

            }
            return BadRequest("Could not add the photo ...");
        }




    }
}