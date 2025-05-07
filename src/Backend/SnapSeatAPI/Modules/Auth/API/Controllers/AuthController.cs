using Auth.Application.DTOs;
using Auth.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode, new { error = result.Error });
            }
            return StatusCode((int)result.StatusCode, result.Value);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode, new { error = result.Error });
            }
            return StatusCode((int)result.StatusCode, result.Value);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest request)
        {
            var result = await _authService.RefreshAsync(request);
            if (!result.IsSuccess)
            {
                return StatusCode((int)result.StatusCode, new { error = result.Error });
            }
            return StatusCode((int)result.StatusCode, result.Value);
        }
    }
}
