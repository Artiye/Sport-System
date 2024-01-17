using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_System.Infrastructure.Migrations
{
    public partial class addToDB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23453453451092347944");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId1293931239438254523",
                column: "ConcurrencyStamp",
                value: "1f6d04fc-fa94-4aeb-a6b3-d90708f4b853");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23094852091092347944",
                column: "ConcurrencyStamp",
                value: "fa70e9f9-fdf0-41bf-bc8b-f85357dd161b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "playerRoleId2345123412339234794", "65bbc992-1e33-4b2f-8b3e-af095e82ae82", "Player", "PLAYER" },
                    { "teamOwnerRoleId23453453451092312341", "a499a182-53b9-4865-8444-2f3d8783115e", "TeamOwner", "TEAMOWNER" },
                    { "tournamentAdministratorRoleId2345334566", "9a2db018-3a8d-401e-8e83-0b9a48331d62", "TournamentAdministrator", "TOURNAMENTADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "895736c4-16f8-4993-a30c-a893a327caec", "AQAAAAEAACcQAAAAEKExXiQS9WlvgM3KJOmkNSydNPSjelryj5dqrGIHGOvaDqbG1ZB1u8PIZ+9jFsBj+A==", "4f35ba4a-fbb0-496b-bc1b-2984b1183b42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "defaultuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15f654ea-3bd4-49ed-be9b-6653f05c423f", "AQAAAAEAACcQAAAAEC3jOuGgXxG5xPVPGiw0Pub15yRM7gR+u7aExD9Vdfa4JHXVOyyQaz4DI95oqF+b/g==", "7ccd4c34-e8e0-46b9-bd1e-1f48a0e6370f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "playerRoleId2345123412339234794");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "teamOwnerRoleId23453453451092312341");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "tournamentAdministratorRoleId2345334566");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId1293931239438254523",
                column: "ConcurrencyStamp",
                value: "e357537a-2712-411a-b309-5262a434fd08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23094852091092347944",
                column: "ConcurrencyStamp",
                value: "1f5a6b1b-febb-4e8d-9ae4-eb5bf123b011");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "userRoleId23453453451092347944", "f9983f88-faef-440c-9909-bfbbf4215665", "TeamOwner", "TEAMOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5196f823-e9b0-41d3-b8d2-b2c126df81af", "AQAAAAEAACcQAAAAEMxzK/HOECzmF2xCUd/WxeCynkZMwYTbBQkNE+SLWnOw7eGV5hFJPB7efWHgmvOVPQ==", "0ca3fd9d-543d-4af9-a1de-a482fbcb5600" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "defaultuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5e7a36-553c-4d83-92ed-e21f56a9c79f", "AQAAAAEAACcQAAAAEDOVprZrhaqLhLKa2pa0r0HXw/6nL67KKaG5P7S5XpSzjbHiVYGqhJsELJnxLNTiJA==", "c8bb0e32-e414-4725-bff2-1289be9091e2" });
        }
    }
}
