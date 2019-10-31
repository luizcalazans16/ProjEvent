using System;

namespace ProjEventWeb.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Cpf { get; set; }
        public string SubscriptionType { get; set; }
        public string Gender { get; set; }
        public  string Password {get; set;}
        public string Course {get; set;}
        public bool Administrator {get; set;}
    }

}
