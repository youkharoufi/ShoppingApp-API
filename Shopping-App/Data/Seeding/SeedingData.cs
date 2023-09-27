using Microsoft.AspNetCore.Identity;
using Shopping_App.Models;

namespace Shopping_App.Data.Seeding
{
    public static class SeedingData
    {
        public static async Task SeedDataAsync(DataContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Users.Any())
            {
                ApplicationUser user1 = new ApplicationUser
                {
                    UserName = "Youssef",
                    Email = "youssef@gmail.com",
                    Token = ""

                };

                ApplicationUser user2 = new ApplicationUser
                {
                    UserName = "Henry",
                    Email = "henry@gmail.com",
                    Token = ""
                };

                ApplicationUser user3 = new ApplicationUser
                {
                    UserName = "Estelle",
                    Email = "estelle@gmail.com",
                    Token = ""
                };

                userManager.CreateAsync(user1, "Pa$$w0rd").GetAwaiter().GetResult();
                userManager.CreateAsync(user2, "Pa$$w0rd").GetAwaiter().GetResult();
                userManager.CreateAsync(user3, "Pa$$w0rd").GetAwaiter().GetResult();

            }
        }
    }
}
