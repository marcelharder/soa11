using System;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UserForRegisterDto
    {

       

        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage="Password should be minimum 6 and max 8 char")]
        public string password { get; set; }
       
       

    }
}