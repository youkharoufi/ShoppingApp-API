using Microsoft.AspNetCore.Identity;
using Shopping_App.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;


namespace Shopping_App.Data.Seeding
{
    public static class SeedingData
    {
        public static IHttpContextAccessor? HttpContextAccessor { get; set; }


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

            if (!context.Products.Any())
            {

                Uri uri = new Uri("https://localhost:7180/");

                List<Product> allProducts = new List<Product>
                {
                //Boots : 
                new Product
                {
                    ProductName = "Leather Red Shoe",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.99,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/b1.jpg"

                },
                

                new Product
                {
                    ProductName = "Leather Beige Shoe",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.99,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/b2.jpg"
                },

                new Product
                {
                    ProductName = "Leather Blue Shoe",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.99,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/b3.jpg"
                },

                new Product
                {
                    ProductName = "Leather Black Shoe",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.99,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/b4.jpg"
                },

                //Electronics : 

                new Product
                {
                    ProductName = "KODAK PIXPRO Astro",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 287.93,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/4.jpg",
                    PhotoUrl2 = $"{uri}/images/products/large/f1.jpg",
                    PhotoUrl3 = $"{uri}/images/products/large/f2.jpg",
                    PhotoUrl4 = $"{uri}/images/products/large/f3.jpg",
                },

                new Product
                {
                    ProductName = "Canon EOS Rebel T7",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 255.92,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/5.jpg",
                    PhotoUrl2 = $"{uri}/images/products/large/f1.jpg",
                    PhotoUrl3 = $"{uri}/images/products/large/f2.jpg",
                    PhotoUrl4 = $"{uri}/images/products/large/f3.jpg",
                },

                new Product
                {
                    ProductName = "Panasonic DMCFZ300K",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 729.00,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/9.jpg",
                    PhotoUrl2 = $"{uri}/images/products/large/f1.jpg",
                    PhotoUrl3 = $"{uri}/images/products/large/f2.jpg",
                    PhotoUrl4 = $"{uri}/images/products/large/f3.jpg",
                },

                new Product
                {
                    ProductName = "Leica V-Lux 5",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 287.93,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/11.jpg",
                    PhotoUrl2 = $"{uri}/images/products/large/f1.jpg",
                    PhotoUrl3 = $"{uri}/images/products/large/f2.jpg",
                    PhotoUrl4 = $"{uri}/images/products/large/f3.jpg",
                },

                new Product
                {
                    ProductName = "Nikon Coolpix L340",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 298.95,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/13.jpg",
                },

                new Product
                {
                    ProductName = "Panasonic lumix fs16",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.87,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/2.jpg",
                },

                new Product
                {
                    ProductName = "Panasonic lumix fs16 ",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.87,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/1.jpg",
                },

                new Product
                {
                    ProductName = "Panasonic lumix fs25",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.87,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/3.jpg",
                },

                new Product
                {
                    ProductName = "Panasonic lumix fs25",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 129.87,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/13.jpg",
                },

                //USBs and Memory Cards :

                new Product
                {
                    ProductName = "SanDisk Extreme PRO ",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 30.21,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/8.jpg",
                },

                new Product
                {
                    ProductName = "SanDisk PRO SDSD",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 30.21,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/6.jpg",
                },

                new Product
                {
                    ProductName = "Sandisk Ultra Flair",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 29.21,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/7.jpg",
                },

                new Product
                {
                    ProductName = "SanDisk Extreme PRO ",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 30.21,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/12.jpg",
                },

                new Product
                {
                    ProductName = "SanDisk PRO SDSD",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Price = 30.21,
                    Quantity = 1,
                    PhotoUrl1 = $"{uri}/images/products/10.jpg",
                },

                //Kindle and panasonic :

                };


            foreach (var product in allProducts)
                    {
                        context.Products.Add(product);

                    }
                
                await context.SaveChangesAsync();


            }
        }
    }
}
