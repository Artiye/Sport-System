using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TournamentDTOs
{
    public class EditTournamentLogoDTO
    {
        public int TournamentId { get; set; }
        public IFormFile Logo { get; set; }
    }
}
