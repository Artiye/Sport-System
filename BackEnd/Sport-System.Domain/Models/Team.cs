using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sport_System.Domain.Models;

namespace Sport_System.Domain.Entity
{
    public class Team
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
        public ApplicationUser TeamOwner { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public string SportName { get; set; }
      
    }
}
