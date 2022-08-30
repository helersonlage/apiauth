using apiauth.Models;
using apiauth.Repositories;
using apiauth.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiauth.Controllers
{

    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {

        private readonly ISettings _settings;
        public LoginController(ISettings settings) { _settings = settings; }


        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Auth(UserLogin userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.UserName) || string.IsNullOrEmpty(userLogin.Password))
            {
                return BadRequest(new { message = "Invalid user or password." });
            }

            var user = UserRepository.Get(userLogin.UserName, userLogin.Password);


            if (user != null)
            {
                string token = new TokenService(_settings).GenerateToken(user);
                user.Password = string.Empty;
                return new
                {
                    user,
                    token
                };

            }
            else
            {
                return BadRequest(new { message = "Invalid user or password." });
            }

        }

    }
}
