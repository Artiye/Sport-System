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
        Task<GetUserDto> GetUserByIdAsync(string userId);
    }
}