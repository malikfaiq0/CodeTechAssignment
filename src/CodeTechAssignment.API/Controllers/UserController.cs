using CodeTechAssignment.Core.DTOs;
using CodeTechAssignment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeTechAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto request)
        {
            var result = await _userService.RegisterNewCustomerAsync(request);
            return Ok(new { message = result });
        }

        [HttpPost("migrate")]
        public async Task<IActionResult> Migrate([FromBody] MigrateUserDto request)
        {
            var result = await _userService.MigrateExistingUserAsync(request);
            return Ok(new { message = result });
        }
    }
}
