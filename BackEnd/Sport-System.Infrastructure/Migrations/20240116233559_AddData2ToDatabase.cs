using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_System.Infrastructure.Migrations
{
    public partial class AddData2ToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "userRoleId23453453451092347944", "292e2cf2-18f7-463d-8fe1-9cc403e6a1a0", "TeamOwner", "TEAMOWNER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
