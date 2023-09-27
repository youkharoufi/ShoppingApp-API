using Microsoft.AspNetCore.Identity;

namespace Shopping_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Token { get; set; }
    }
}
