using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_.Application.DTOs.PlayerDTOs
{
    public class EditPlayerDTO
    {
        public int PlayerId { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
    }
}
