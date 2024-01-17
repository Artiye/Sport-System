using Sport_System.Application.DTOs.TeamDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TournamentDTOs
{
    public class GetTournamentDTO
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GetOnlyTeamDTO>? Teams { get; set; }
        public string TournamentAdministratorId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
    }
}
