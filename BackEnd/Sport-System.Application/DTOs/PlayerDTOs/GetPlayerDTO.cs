
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.PlayerDTOs
{
    public class GetPlayerDTO
    {
        public int PlayerId { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
      
        public DateTime Registered_At { get; set; }
        public int SportId { get; set; }
        public int TeamId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
