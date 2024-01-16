using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Infrastructure.Data.DataSeed
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "adminuser11234980723452903459235",
                    UserName = "admin",
                    FirstName = "Admin",
                    LastName = "User",
                    Gender = "Male",
                    Nationality = "Albanian",
                    ProfileUrl = "/images/profilepicture.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "kbacaj5@gmail.com",
                    NormalizedEmail = "KBACAJ5@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "admin123123"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser
                {
                    Id = "defaultuser11234980723452903459235",
                    UserName = "defaultUser",
                    FirstName = "Default",
                    LastName = "User",
                    Gender = "Male",
                    Nationality = "Albanian",
                    ProfileUrl = "/images/profilepicture.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "user123132"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
        }
    }
}