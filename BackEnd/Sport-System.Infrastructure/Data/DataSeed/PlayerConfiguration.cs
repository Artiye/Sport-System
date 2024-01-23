using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sport_System.Domain.Entity;

namespace Sport_System.Infrastructure.Data.DataSeed
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasData(
                new Player
                {
                    PlayerId = 1,
                    Position = "Striker",
                    JerseyNumber = 11,
                    Registered_At = DateTime.Now,
                    TeamId = 4, 
                    ApplicationUserId = "kajtazbacaj542225", 
                    SportId = 3, 
                },

                new Player
                {
                    PlayerId = 2,
                    Position = "Defender",
                    JerseyNumber = 24,
                    Registered_At = DateTime.Now,
                    TeamId = 4, 
                    ApplicationUserId = "flamurraci542225",
                    SportId = 3,
                },

                new Player
                {
                    PlayerId = 3,
                    Position = "Midfielder",
                    JerseyNumber = 23,
                    Registered_At = DateTime.Now,
                    TeamId = 3,
                    ApplicationUserId = "artmorina542225",
                    SportId = 3,
                }

            );
        }
    }
}
