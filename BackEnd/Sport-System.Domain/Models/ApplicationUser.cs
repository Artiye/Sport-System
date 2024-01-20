using Microsoft.AspNetCore.Identity;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string? ProfileUrl { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Team>? Teams { get; set; }
        public ICollection<Player>? Players { get; set; }
        public ICollection<Tournament>? Tournaments { get; set; }
    }
}
