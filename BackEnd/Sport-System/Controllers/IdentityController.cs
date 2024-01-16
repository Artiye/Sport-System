using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport_System.Application.DTOs.IdentityDTOs;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;

namespace Sport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync(RegisterDTO dto)
        {
            var response = await _identityService.RegisterAsync(dto);
            return StatusCode(response.Status, response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ApiResponse>> LoginAsync([FromBody] LoginDTO dto)
        {
            var response = await _identityService.LoginAsync(dto);
            return StatusCode(response.Status, response);
        }

        [HttpGet("ForgotPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            var result = await _identityService.ForgetPasswordAsync(email);
            return StatusCode(result.Status, result);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordDTO dto)
        {
            var result = await _identityService.ResetPasswordAsync(dto);
            return StatusCode(result.Status, result);
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromForm] ChangePasswordDTO dto)
        {
            var result = await _identityService.ChangePasswordAsync(dto);
            return StatusCode(result.Status, result);
        }

    }
}

