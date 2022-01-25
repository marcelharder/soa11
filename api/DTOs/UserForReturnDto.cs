using System;


namespace api.DTOs
{
    public class UserForReturnDto
    {
        public int Id { get; set; }
        public int hospital_id { get; set; }
        public string worked_in { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string role { get; set; }
        public string gender { get; set; }
        public string photoUrl { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime created { get; set; }
        public DateTime lastActive { get; set; }
      
        public string introduction { get; set; }
        public string lookingFor { get; set; }
        public string email {get; set;}
        public string interests { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string iban { get; set; }
        public string mobile { get; set; }
      
        public int country { get; set; }
        public bool active { get; set; }
        public bool ltk { get; set; }
    }
}