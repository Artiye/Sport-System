using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Infrastructure.Data.DataSeed
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "adminuser11234980723452903459235",
                    RoleId = "adminRoleId1293931239438254523",
                },

                new IdentityUserRole<string>
                {
                    UserId = "defaultuser11234980723452903459235",
                    RoleId = "userRoleId23094852091092347944",
                }
            );

        }
    }
}
