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

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthAsync(UserLogin userLogin)
        {

            var user = UserRepository.Get(userLogin.UserName, userLogin.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid user or password." });
            }


            var token = await new TokenService().GenerateTokenAsync(user);

            //TODO map to a new userView without pwd
            user.Password = string.Empty;


            return new
            {
                user,
                token
            };
        }

    }
}
