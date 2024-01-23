using Sport_System.Application.DTOs.IdentityUserDTOs;
using Sport_System.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services.Interfaces
{
    public interface IIdentityUserService
    {
        Task<List<GetUserDto>> GetAllUsersAsync();
        Task<ApiResponse> UpdateUserAsync(EditUserDTO dto);
        Task<ApiResponse> UpdateUserProfilePictureAsync(EditUserProfilePictureDTO dto);
        Task<GetUserDto> GetUserByIdAsync(string userId);
       
    }
}