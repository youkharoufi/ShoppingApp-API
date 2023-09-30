using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                    Token = "",
                    AddressLineOne = "857 Fox street",
                    AddressLineTwo="Apt.356",
                    City="FoxTown",
                    State="FoxState",
                    Country="FoxContry",
                    ZipPostalCode = "18000",
                    DateOfBirth = new DateTime(2000, 12, 17),
                    Firstname = "Youssef",
                    HomePhone = "0654213987",
                    Lastname = "Fox",
                    Title = "Mr.",
                    MobilePhone = "0537749865",

                };

                ApplicationUser user2 = new ApplicationUser
                {
                    UserName = "Henry",
                    Email = "henry@gmail.com",
                    Token = "",
                    AddressLineOne = "147 Avenue street",
                    AddressLineTwo = "Apt.349",
                    City = "FoxTown",
                    State = "FoxState",
                    Country = "FoxContry",
                    ZipPostalCode = "25600",
                    DateOfBirth = new DateTime(1997, 5, 6),
                    Firstname = "Henry",
                    HomePhone = "0621353437",
                    Lastname = "Fox",
                    Title = "Mr.",
                    MobilePhone = "0562958473",
                };

                ApplicationUser user3 = new ApplicationUser
                {
                    UserName = "Estelle",
                    Email = "estelle@gmail.com",
                    Token = "",
                    AddressLineOne = "578 Yellow Submarine street",
                    AddressLineTwo = "Apt.126",
                    City = "FoxTown",
                    State = "FoxState",
                    Country = "FoxContry",
                    ZipPostalCode = "12000",
                    DateOfBirth = new DateTime(1998, 7, 14),
                    Firstname = "Estelle",
                    HomePhone = "0624158937",
                    Lastname = "Fox",
                    Title = "Mrs.",
                    MobilePhone = "0521369635",
                };

                userManager.CreateAsync(user1, "Pa$$w0rd").GetAwaiter().GetResult();
                userManager.CreateAsync(user2, "Pa$$w0rd").GetAwaiter().GetResult();
                userManager.CreateAsync(user3, "Pa$$w0rd").GetAwaiter().GetResult();

            }
        }
    }
}
