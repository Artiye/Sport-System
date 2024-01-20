using Sport_System.Domain.Entity;
using System.Numerics;

namespace Sport_System.Domain.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
