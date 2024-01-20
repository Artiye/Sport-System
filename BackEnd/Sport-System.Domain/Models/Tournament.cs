using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Domain.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public string? Location { get; set; }
        public string? Rules { get; set; }
        public ICollection<Team>? Teams { get; set; }
        public string TournamentAdministratorId { get; set; }
        public ApplicationUser TournamentAdministrator { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public string SportName { get; set; }
    }
}
