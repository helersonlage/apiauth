using apiauth.Model;

namespace apiauth.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}