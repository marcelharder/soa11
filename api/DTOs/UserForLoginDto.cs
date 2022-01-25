using System.ComponentModel.DataAnnotations;

namespace api.DTOs
{
    public class UserForLoginDto
    {
             public string UserName { get; set; }
             
             public string password { get; set; }  
    }
}