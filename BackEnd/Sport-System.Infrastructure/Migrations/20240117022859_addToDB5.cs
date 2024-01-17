using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_System.Infrastructure.Migrations
{
    public partial class addToDB5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BracketId = table.Column<int>(type: "int", nullable: true),
                    TournamentAdministratorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournaments_AspNetUsers_TournamentAdministratorId",
                        column: x => x.TournamentAdministratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tournaments_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23453453451092347944",
                column: "ConcurrencyStamp",
                value: "f9983f88-faef-440c-9909-bfbbf4215665");

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

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_SportId",
                table: "Tournaments",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentAdministratorId",
                table: "Tournaments",
                column: "TournamentAdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tournaments_TournamentId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TournamentId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId1293931239438254523",
                column: "ConcurrencyStamp",
                value: "118e54a3-0ae4-4cec-b5dd-37693472a439");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23094852091092347944",
                column: "ConcurrencyStamp",
                value: "d6254672-eceb-4d70-aca5-ebc68fcbbee8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23453453451092347944",
                column: "ConcurrencyStamp",
                value: "292e2cf2-18f7-463d-8fe1-9cc403e6a1a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c10a7b7a-2c2f-4b03-b2e4-3f90a63d9e92", "AQAAAAEAACcQAAAAEKd7OuyY/TS5ivbwmzwoepzBXHHzvzM6lRbMZ6UCPb6QjG1+RSy1TS9i5aRsBeI3+A==", "4f1f23d1-bb4d-4ae9-8874-9938dc830e05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "defaultuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae97c582-dc68-4554-8ed2-4676ce8d363b", "AQAAAAEAACcQAAAAECzgh7CjUhASW+6PNp7CZKbd4BRYF4iCvaecglnLmQI48TWnhPGbo6y9oR55bUsp7g==", "89dea52a-8e0c-41ea-b027-47ad1c94d7c5" });
        }
    }
}
