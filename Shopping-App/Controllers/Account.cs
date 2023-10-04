using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_App.Models;
using Shopping_App.Token;

namespace Shopping_App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _token;
        private readonly IMapper _mapper;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService token, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApplicationUser>> register(RegisterUser registerUser)
        {
            var newUser = new ApplicationUser
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
                AddressLineOne = registerUser.AddressLineOne,
                AddressLineTwo = registerUser.AddressLineTwo,
                City = registerUser.City,
                State = registerUser.State,
                Country = registerUser.Country,
                ZipPostalCode = registerUser.ZipPostalCode,
                DateOfBirth = registerUser.DateOfBirth,
                Firstname = registerUser.Firstname,
                HomePhone = registerUser.HomePhone,
                Lastname = registerUser.Lastname,
                Title = registerUser.Title,
                MobilePhone = registerUser.MobilePhone,
                Token = "",
            };

            var result = await _userManager.CreateAsync(newUser, registerUser.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => e.Description));

            }

            return Ok(newUser);

        }

        [HttpPost("login")]
        public async Task<ActionResult<ApplicationUser>> login(LoginUser loginUser)
        {
            var userFromDb = await _userManager.Users.FirstOrDefaultAsync(i =>(i.Email == loginUser.EmailOrUserName) || (i.UserName == loginUser.EmailOrUserName));

            if (userFromDb == null) return NotFound("No such user is registered");

            var resultA = await _signInManager.CheckPasswordSignInAsync(userFromDb, loginUser.Password, false);

            if (!resultA.Succeeded) return BadRequest("Invalid Password");

            userFromDb.Token = await _token.GenerateToken(userFromDb);

            return Ok(userFromDb);
        }
    }
}
