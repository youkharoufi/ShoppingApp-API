using Shopping_App.Models;

namespace Shopping_App.Token
{
    public interface ITokenService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
