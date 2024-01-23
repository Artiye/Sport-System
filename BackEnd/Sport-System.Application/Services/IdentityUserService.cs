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
        private readonly IPhotoSaver _photoSaver;

        public IdentityUserService(UserManager<ApplicationUser> userManager, IMapper mapper, IPhotoSaver photoSaver)
        {
            _userManager = userManager;
            _mapper = mapper;
            _photoSaver = photoSaver;
        }

        public async Task<List<GetUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<GetUserDto>>(users);

            foreach (var userDto in result)
            {
                var user = users.FirstOrDefault(u => u.Id == userDto.Id);
                if (user != null)
                {
                    userDto.Roles = (await _userManager.GetRolesAsync(user)).ToList();
                }
            }
            return result;
        }

      

        public async Task<ApiResponse> UpdateUserAsync(EditUserDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null) return new ApiResponse(404, "User not found.");

            if (user.FirstName == dto.FirstName &&
                user.LastName == dto.LastName &&
                user.Email == dto.Email &&
                user.DateOfBirth == dto.DateOfBirth &&
                user.Gender == dto.Gender &&
                user.UserName == dto.Username &&
                user.Nationality == dto.Nationality)
            { return new ApiResponse(400, "No changes were made."); }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.DateOfBirth = dto.DateOfBirth;
            user.Gender = dto.Gender;
            user.UserName = dto.Username;
            user.Nationality = dto.Nationality;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return new ApiResponse(200, "User updated successfully.");
            return new ApiResponse(400, "Failed to update user.");
        }

        public async Task<ApiResponse> UpdateUserProfilePictureAsync(EditUserProfilePictureDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null) return new ApiResponse(404, "User not found.");

            if (dto.ProfileUrl != null)
            {
                string oldPhotoFilePath = "../../../FrontEnd/public" + user.ProfileUrl;
                string newPhotoFilePath = await _photoSaver.SavePhoto(dto.ProfileUrl);
                user.ProfileUrl = newPhotoFilePath;

                if (!string.IsNullOrEmpty(user.ProfileUrl) && !string.Equals(user.ProfileUrl, "/images/profilepicturedefault.jpg") && File.Exists(oldPhotoFilePath))
                    File.Delete(oldPhotoFilePath);
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return new ApiResponse(200, "User updated successfully.");
            return new ApiResponse(400, "Failed to update user.");
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
