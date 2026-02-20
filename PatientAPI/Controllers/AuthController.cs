using Microsoft.AspNetCore.Mvc;
using PatientAPI.Services;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.Login(request);
            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password");
        }
    }
}
