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
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasData(
                new Sport
                {
                    SportId = 1,  
                    Name = "Football",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 2,
                    Name = "Basketball",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 3,
                    Name = "Volleyball",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 4,
                    Name = "Mixed Martial Arts",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 5,
                    Name = "Swimming",
                    Description = "Sport",
                }, 
                
                new Sport
                {
                    SportId = 6,
                    Name = "Volleyball",
                    Description = "Sport",
                }, 
                
                new Sport
                {
                    SportId = 7,
                    Name = "Boxing",
                    Description = "Sport",
                }, 
                
                new Sport
                {
                    SportId = 8,
                    Name = "Baseball",
                    Description = "Sport",
                }, 
                 
                new Sport
                {
                    SportId = 9,
                    Name = "Golf",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 10,
                    Name = "Hockey",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 11,
                    Name = "Skiing",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 12,
                    Name = "American Football",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 13,
                    Name = "Bowling",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 14,
                    Name = "Skating",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 15,
                    Name = "Judo",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 16,
                    Name = "Kickboxing",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 17,
                    Name = "Hockey",
                    Description = "Sport",
                },

                new Sport
                {
                    SportId = 18,
                    Name = "Wrestrling",
                    Description = "Sport",
                }
            );
        }
    }
}
