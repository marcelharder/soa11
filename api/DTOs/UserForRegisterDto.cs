using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UserForRegisterDto
    {

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage="Password should be minimum 6 and max 8 char")]
        public string password { get; set; }
        public string worked_in { get; set; }
        public int hospital_id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }
       

    }
}