using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Sport_System.Application.DTOs.IdentityDTOs;
using Sport_System.Application.Responses;
using Sport_System.Application.Services.Interfaces;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Models;
using Sport_System.Domain.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, ITokenGenerator tokenGenerator, IEmailSender emailSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _tokenGenerator = tokenGenerator;
            _emailSender = emailSender;
        }

        public async Task<ApiResponse> RegisterAsync(RegisterDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user != null)
                return new ApiResponse(400, "This User Exists.");

            if (dto.Password != dto.ConfirmPassword)
                return new ApiResponse(400, "Password and Confirm Password do not Match.");

            var applicationUser = _mapper.Map<ApplicationUser>(dto);
            applicationUser.ProfileUrl = "/images/profilepicturedefault.jpg";

            var result = await _userManager.CreateAsync(applicationUser, dto.Password);
            if (!result.Succeeded)
                return new ApiResponse(400, "Something went Wrong.");

            var addingUser = await _userManager.AddToRoleAsync(applicationUser, UserRoles.RegisteredUser);
            if (addingUser.Succeeded)
                return new ApiResponse(200, "User was Registered. Please Login!");

            return new ApiResponse(400, "Something went Wrong.");
        }

        public async Task<JwtResponse> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return new JwtResponse(400, "Email was Incorrect.");

            var userPassword = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!userPassword)
                return new JwtResponse(400, "Password was Incorrect.");

            var userRoles = await _userManager.GetRolesAsync(user);
            if (userRoles != null)
            {
                var jwtToken = _tokenGenerator.GenerateJwtToken(user, userRoles.ToList());
                var tokenExpiration = DateTime.Now.AddMinutes(30);
                var userId = user.Id;
                return new JwtResponse(200, "Successful Login.", jwtToken, tokenExpiration, userId, userRoles.ToList());
            }

            return new JwtResponse(400, "Something Went Wrong.");
        }

        public async Task<ApiResponse> ForgetPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ApiResponse(400, "No User Associated with this Email.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var encodedToken = Encoding.UTF8.GetBytes(token);
            var validToken = WebEncoders.Base64UrlEncode(encodedToken);

            string url = $"{"http://localhost:3000"}/ResetPassword/{email}/{validToken}";

            await _emailSender.SendEmailAsync(email, "Ndërro Fjalëkalimin",
                "Ndiqni udhëzimet për të ndërruar fjalëkalimin tuaj."
                 + $"<p>Për të ndërruar fjalëkalimin tuaj, <a href='{url}'>Kliko këtu</a>.</p>");

            return new ApiResponse(200, "Reset password URL has been sent to the email successfully!");
        }

        public async Task<ApiResponse> ResetPasswordAsync(ResetPasswordDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return new ApiResponse(400, "No User Associated with this Email.");

            if (dto.NewPassword != dto.ConfirmPassword)
                return new ApiResponse(400, "Passwords do not Match.");

            var decodedToken = WebEncoders.Base64UrlDecode(dto.Token);
            var normalToken = Encoding.UTF8.GetString(decodedToken);

            var resetPassword = await _userManager.ResetPasswordAsync(user, normalToken, dto.NewPassword);
            if (resetPassword.Succeeded)
                return new ApiResponse(200, "Password has been reset Succesfully.");

            return new ApiResponse(400, "Something went Wrong.");
        }
        public async Task<ApiResponse> ChangePasswordAsync(ChangePasswordDTO dto)
        {
            var user = await _userManager.FindByIdAsync(dto.userId);
            if (user == null)
            {
                return new ApiResponse(404, "User not found.");
            }

            if (dto.NewPassword != dto.ConfirmNewPassword)
            {
                return new ApiResponse(400, "New password and confirmation do not match.");
            }
            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);

            if (result.Succeeded)
            {
                return new ApiResponse(200, "Password changed successfully.");
            }
            else
            {
                return new ApiResponse(400, "Failed to change password. Ensure that the old password is correct and the new password meets the security requirements.");
            }
        }
    }
}
