using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TournamentDTOs
{
    public class AddTournamentDTO
    {
        [StringLength(25, ErrorMessage = "The Name cannot exceed 25 characters.")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile Logo { get; set; }
        public string TournamentAdministratorId { get; set; }
        public int SportId { get; set; }
    }
}
