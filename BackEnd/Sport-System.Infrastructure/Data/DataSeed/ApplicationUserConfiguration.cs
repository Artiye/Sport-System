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
                    Id = "kajtazbacaj542225",
                    UserName = "KajtazBacaj",
                    FirstName = "Kajtaz",
                    LastName = "Bacaj",
                    Gender = "Male",
                    Nationality = "Albanian",
                    ProfileUrl = "/images/profilepicture3.png",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "kbacaj5@gmail.com",
                    NormalizedEmail = "KBACAJ5@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "kajtazbacaj"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser
                {
                    Id = "flamurraci542225",
                    UserName = "FlamurRaci",
                    FirstName = "Flamur",
                    LastName = "Raci",
                    Gender = "Male",
                    Nationality = "Albanian",
                    ProfileUrl = "/images/profilepicture2.png",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "flamurraci@gmail.com",
                    NormalizedEmail = "FLAMURRACI@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "flamurraci"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

                new ApplicationUser
                {
                    Id = "artmorina542225",
                    UserName = "ArtMorina",
                    FirstName = "Art",
                    LastName = "Morina",
                    Gender = "Male",
                    Nationality = "Albanian",
                    ProfileUrl = "/images/profilepicture4.png",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    Email = "artmorina@gmail.com",
                    NormalizedEmail = "ARTMORINA@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "artmorina"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },

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
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
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
                    ProfileUrl = "/images/profilepicturedefault.jpg",
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