using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.IdentityUserDTOs
{
    public class EditUserProfilePictureDTO
    {
        public string Id { get; set; }
        public IFormFile ProfileUrl { get; set; }
    }
}
