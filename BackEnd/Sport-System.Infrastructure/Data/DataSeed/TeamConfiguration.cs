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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasData(
                new Team 
                {
                    TeamId = 1,
                    Name = "FC Barcelona",
                    Description = "Spanish Football Team.",
                    LogoUrl = "/images/fcbarcelona.png",
                    Registered_At = DateTime.UtcNow,
                    TeamOwnerId = "flamurraci542225",
                    SportId = 1,
                    SportName = "Football"
                },

                new Team
                {
                    TeamId = 2,
                    Name = "AC Milan",
                    Description = "Italian Football Team",
                    LogoUrl = "/images/milan.png",
                    TeamOwnerId = "kajtazbacaj542225",
                    SportId = 1,
                    SportName = "Football"
                },

                new Team 
                { 
                    TeamId = 3, 
                    Name = "Real Madrid", 
                    Description = "Spanish Football Team",
                    LogoUrl = "/images/realmadrid.png",
                    TeamOwnerId = "kajtazbacaj542225", 
                    SportId = 1,
                    SportName = "Football"
                },

                new Team
                {
                    TeamId = 4,
                    Name = "Chelsea FC",
                    Description = "English Football Team",
                    LogoUrl = "/images/chelsea.png",
                    TeamOwnerId = "artmorina542225",
                    SportId = 1,
                    SportName = "Football"
                },

                new Team 
                { 
                    TeamId = 5, 
                    Name = "LA Lakers", 
                    Description = "NBA Team",
                    LogoUrl = "/images/lakers.png",
                    TeamOwnerId = "artmorina542225", 
                    SportId = 2 ,
                    SportName = "Basketball"
                }
            );
        }
    }
}
