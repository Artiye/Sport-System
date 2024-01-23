using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sport_System.Domain.Models;

namespace Sport_System.Infrastructure.Data.DataSeed
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasData(
                new Tournament
                {
                    TournamentId = 1,
                    Name = "Champions League",
                    Description = "Europian Clubs Competition.",
                    ImageUrl = "/images/champions.png",
                    TournamentAdministratorId = "artmorina542225", 
                    SportId = 1,
                    SportName = "Football"
                },
                                    
                new Tournament
                {
                    TournamentId = 2,
                    Name = "Europa League",
                    Description = "Europian Clubs Competition.",
                    ImageUrl = "/images/europian.png",
                    TournamentAdministratorId = "artmorina542225",
                    SportId = 1,
                    SportName = "Football"
                },

                new Tournament
                {
                    TournamentId = 3,
                    Name = "Liga e Kosoves",
                    Description = "Europian Clubs Competition.",
                    ImageUrl = "/images/ligakosoves.png",
                    TournamentAdministratorId = "kajtazbacaj542225",
                    SportId = 1,
                    SportName = "Football"
                },

                new Tournament
                {
                    TournamentId = 4,
                    Name = "NBA Play-Offs",
                    Description = "NBA Teams compete of Glory.",
                    ImageUrl = "/images/nbaplayoffs.png",
                    TournamentAdministratorId = "kajtazbacaj542225",
                    SportId = 2,
                    SportName = "Basketball"
                },

                new Tournament
                {
                    TournamentId = 5,
                    Name = "Europa Conference League",
                    Description = "Europian Clubs Compete.",
                    ImageUrl = "/images/europeconference.png",
                    TournamentAdministratorId = "flamurraci542225",
                    SportId = 1,
                    SportName = "Football"
                }

            );
        }
    }
}
