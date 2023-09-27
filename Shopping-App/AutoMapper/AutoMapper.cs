using AutoMapper;
using Shopping_App.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shopping_App.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterUser, ApplicationUser>();

        }
    }
}
