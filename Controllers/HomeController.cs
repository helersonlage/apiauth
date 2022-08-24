using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiauth.Controllers
{
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        [Route("guitarrist")]
        [Authorize(Roles = ("Guitarrist"))]

        public string guitar()
        {
            return $"Guitar name is {User.Identity?.Name ?? String.Empty}";
        }


        [HttpGet]
        [Route("vocalist")]
        [Authorize(Roles = ("Vocalist"))]
        public string Singer()
        {
            return $"Singer name is {User.Identity?.Name ?? String.Empty}";
        }



        [HttpGet]
        [Route("whoami")]
        [Authorize]
        public string WhoAmI()
        {
            return $" I am {User.Identity.Name}";
        }




    }
}
