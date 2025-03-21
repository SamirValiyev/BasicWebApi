using Microsoft.AspNetCore.Mvc;

namespace BasicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            return Created("",new JwtTokenGenerator().GenerateToken());
        }
    }
}
