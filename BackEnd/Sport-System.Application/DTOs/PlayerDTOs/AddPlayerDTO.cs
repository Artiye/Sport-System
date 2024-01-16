using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.PlayerDTOs
{
    public class AddPlayerDTO
    {
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public int TeamId { get; set; }
        public int SportId { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
