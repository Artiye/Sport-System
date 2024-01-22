using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport_System.Application.DTOs.IdentityUserDTOs;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;

namespace Sport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {
        private readonly IIdentityUserService _identityUserService;
        public UserManagmentController(IIdentityUserService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<ActionResult<GetUserDto>> GetUserById(string userId)
        {
            var user = await _identityUserService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound($"User with ID {userId} not found.");

            return Ok(user);
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<GetUserDto>>> GetAllUsers()
        {
            return await _identityUserService.GetAllUsersAsync();
        }
    }
}
