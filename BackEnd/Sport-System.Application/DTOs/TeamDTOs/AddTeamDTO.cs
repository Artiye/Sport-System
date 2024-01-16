using Microsoft.AspNetCore.Http;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TeamDTOs
{
    public class AddTeamDTO
    {
        [StringLength(20, ErrorMessage = "The Name cannot exceed 20 characters.")]
        public string Name { get; set; }
        [StringLength(8, ErrorMessage = "The Short Name cannot exceed 8 characters.")]
        public string? ShortName { get; set; }
        public int? YearFounded { get; set; }
        public string? Description { get; set; }
        public IFormFile Logo { get; set; }
        public string TeamOwnerId { get; set; }
        public int SportId { get; set; }
    }
}
