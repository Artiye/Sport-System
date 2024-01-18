using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sport_System.Application.DTOs.IdentityUserDTOs;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public IdentityUserService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null) return null;

            var dto = _mapper.Map<GetUserDto>(user);
            dto.Roles = (await _userManager.GetRolesAsync(user)).ToList();


            return dto;
        }

    }
}
