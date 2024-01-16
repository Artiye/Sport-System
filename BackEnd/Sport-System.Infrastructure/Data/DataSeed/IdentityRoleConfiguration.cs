using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Infrastructure.Data.DataSeed
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Id = "adminRoleId1293931239438254523", Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() },
                new IdentityRole { Id = "userRoleId23094852091092347944", Name = UserRoles.RegisteredUser, NormalizedName = UserRoles.RegisteredUser.ToUpper() },
                new IdentityRole { Id = "userRoleId23453453451092347944", Name = UserRoles.TeamOwner, NormalizedName = UserRoles.TeamOwner.ToUpper() });


        }
    }
}
