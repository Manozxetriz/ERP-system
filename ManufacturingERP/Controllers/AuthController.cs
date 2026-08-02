using ManufacturingERP.Application.Dtos.Authentication;
using ManufacturingERP.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManufacturingERP.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            await _authService.RegisterAsync(request);

            return Ok(new
            {
                Message = "User registered successfully."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);

            return Ok(response);
        }
    }
}
