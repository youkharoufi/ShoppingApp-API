using Microsoft.AspNetCore.Identity;

namespace Shopping_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Title { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipPostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string Token { get; set; }
    }
}
