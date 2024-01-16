using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TeamDTOs
{
    public class GetOnlyTeamDTO
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string? ShortName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? YearFounded { get; set; }
        public string LogoUrl { get; set; }
        public DateTime Registered_At { get; set; }
        public string TeamOwnerId { get; set; }
        public int SportId { get; set; }
        public string SportName { get; set; }
       
    }
}
