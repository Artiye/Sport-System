﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.IdentityUserDTOs
{
    public class EditUserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Roles { get; set; }
    }
}
