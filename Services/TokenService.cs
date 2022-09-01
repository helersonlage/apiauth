using apiauth.Model;
using apiauth.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiauth.Services
{
    public class TokenService : ITokenService
    {
        private readonly ISettings _settings;
        public TokenService(ISettings settings) { _settings = settings; }

        public string GenerateToken(User user)
        {

            var TokenHandler = new JwtSecurityTokenHandler();
            //Get Secret Key
            var Key = Encoding.ASCII.GetBytes(_settings.GetSecretKey());

            var TokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[] {
                     //Aspnet User.Identity.Name
                    new Claim(ClaimTypes.Name, user.FullName?? string.Empty),
                    // Aspnet.IsInRole
                    new Claim(ClaimTypes.Role, user.Role?? string.Empty),
                }),

                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token) ?? string.Empty;

        }
    }
}
