using apiauth.Model;
using apiauth.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apiauth.Services
{
    public class TokenService
    {
        // private readonly ISettings _settings;

        // public TokenService(ISettings settings) { _settings = settings; }

        public async Task<string> GenerateTokenAsync(User user)
        {

            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(new Settings().GetSecretKey());

            var TokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name, user.FullName), //Aspnet User.Identity.Name
                    new Claim(ClaimTypes.Role, user.Role), // Aspnet.IsInRole
                   // new Claim(ClaimTypes.Role, "Vocalist"),
                    

                }),

                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token);

        }
    }
}
