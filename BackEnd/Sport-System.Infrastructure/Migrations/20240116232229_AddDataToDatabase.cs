using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_System.Infrastructure.Migrations
{
    public partial class AddDataToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Registered_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId1293931239438254523",
                column: "ConcurrencyStamp",
                value: "ebd5ee57-0e1d-4ba8-8acf-447902fa8e33");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23094852091092347944",
                column: "ConcurrencyStamp",
                value: "543b7c20-35d3-42f8-9fcc-42f456be1879");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d15f43c1-0849-42d9-a14d-215e905316dd", "AQAAAAEAACcQAAAAEGQ0uB+SyxkNYpJjxd0DCMbuv+8ndYSjfKgN7GFFL6IxI0pzXfcGqWnhl2UZ7sLprw==", "6d57ffed-3c39-4149-8b26-af9a6aa64652" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "defaultuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6dfd14fe-a1ca-4231-8222-c5264b2262af", "AQAAAAEAACcQAAAAEI+4YUs+glgk2LEi8l99fcD5Fiysq/oOtQrNvqvIN2/Stwq5eZTY4aC8l2HKfp/feg==", "3153491b-1f33-4488-ac43-3d6ff0e486a8" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ApplicationUserId",
                table: "Players",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SportId",
                table: "Players",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adminRoleId1293931239438254523",
                column: "ConcurrencyStamp",
                value: "87de06fa-a3fb-4f6e-9533-64f6123cf457");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "userRoleId23094852091092347944",
                column: "ConcurrencyStamp",
                value: "16916e64-71c6-438e-b512-e707c8e4c434");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6820abbd-ea3f-4692-b070-d086e4004d69", "AQAAAAEAACcQAAAAEOf1EEVM0cQcaL5ueuTPeeRXDgU9iiHpIVtAPp2rU1A0kk1iuOYCJGrGmf20lixmrA==", "815fabb5-3917-418c-80ef-5f4bf0a103d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "defaultuser11234980723452903459235",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ff9de4d-cff9-42f9-8893-b513ef8dad0e", "AQAAAAEAACcQAAAAEI70Ck/Bl9FNbj3W8zEM10PG9gfK5WIOo/eiwBVIoCDA/7TBzDCi6lHmuzdkWFuxCQ==", "3b32cd4b-9dd9-4223-bf79-75a81e9ad5e6" });
        }
    }
}
