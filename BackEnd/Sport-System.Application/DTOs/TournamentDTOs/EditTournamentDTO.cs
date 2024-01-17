using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TournamentDTOs
{
    public class EditTournamentDTO
    {
        public int TournamentId { get; set; }
        [StringLength(25, ErrorMessage = "The Name cannot exceed 25 characters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
