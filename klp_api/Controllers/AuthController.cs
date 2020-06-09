using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using klp_api.Models;

namespace klp_api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> Logger;

        public AuthController(ILogger<AuthController> logger)
        {
            Logger = logger;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            HttpContext.Response.StatusCode = 200;
            return new JsonResult(new GenericResponse
            {
                Message = "Login success",
                Error = null,
                Data = null
            });
        }
    }
}
