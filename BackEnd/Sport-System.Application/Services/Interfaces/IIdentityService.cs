using Sport_System.Application.DTOs.IdentityDTOs;
using Sport_System.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<ApiResponse> RegisterAsync(RegisterDTO dto);
        Task<JwtResponse> LoginAsync(LoginDTO dto);
        Task<ApiResponse> ForgetPasswordAsync(string email);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordDTO dto);
        Task<ApiResponse> ChangePasswordAsync(ChangePasswordDTO dto);

    }
}
