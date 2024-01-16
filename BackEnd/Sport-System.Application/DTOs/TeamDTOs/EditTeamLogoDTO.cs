using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.DTOs.TeamDTOs
{
    public class EditTeamLogoDTO
    {
        public int TeamId { get; set; }
        public IFormFile Logo { get; set; }
    }
}
