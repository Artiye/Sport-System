using Microsoft.AspNetCore.Identity;
using Sport_System.Domain.Entity;
using Sport_System.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Domain.Entity
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public DateTime Registered_At { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
