using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiauth.Controllers
{
    [ApiController]
    public class DemoController : ControllerBase
    {

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => $"I am anonymous user. I don't need be authenticated to run it.";

        [HttpGet]
        [Route("guitarrist")]
        [Authorize(Roles = ("Guitarrist"))]
        public string Guitar() => $"The guitar name is {User?.Identity?.Name}";


        [HttpGet]
        [Route("vocalist")]
        [Authorize(Roles = ("Vocalist"))]
        public string Singer() => $"The singer name is {User?.Identity?.Name}";


        [HttpGet]
        [Route("whoami")]
        [Authorize]
        public string WhoAmI() => $" I am {User?.Identity?.Name}";





    }
}
