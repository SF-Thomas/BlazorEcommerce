using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorEcommerce.Server.Controllers
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
        public async Task<ActionResult<ServiceResponse<int>>> RegisterAsync(UserRegister request)
        {
            var response = await _authService.RegisterAsync(
                new User
                {
                    Email = request.Email
                },
                request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> LoginAsync(UserLogin request)
        {
            var response = await _authService.LoginAsync(request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePasswordAsync([FromBody] string newPassword)
        {
            var nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (int.TryParse(nameIdentifier, out int userId))
            {
                var response = await _authService.ChangePasswordAsync(userId, newPassword);

                if (!response.Success)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }

            return Unauthorized();
        }
    }
}
