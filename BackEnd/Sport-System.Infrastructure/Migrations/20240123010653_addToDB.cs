using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport_System.Infrastructure.Migrations
{
    public partial class addToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearFounded = table.Column<int>(type: "int", nullable: true),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registered_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamOwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_AspNetUsers_TeamOwnerId",
                        column: x => x.TeamOwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId");
                });

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
                        principalColumn: "SportId");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Registered_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId");
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTournament",
                columns: table => new
                {
                    TeamsTeamId = table.Column<int>(type: "int", nullable: false),
                    TournamentsTournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTournament", x => new { x.TeamsTeamId, x.TournamentsTournamentId });
                    table.ForeignKey(
                        name: "FK_TeamTournament_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournament_Tournaments_TournamentsTournamentId",
                        column: x => x.TournamentsTournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "adminRoleId1293931239438254523", "c30d1383-ac8b-4a1c-a7bb-05b95e27c8f7", "Admin", "ADMIN" },
                    { "playerRoleId2345123412339234794", "06a0c669-2e2e-468f-8855-c1da527fadbd", "Player", "PLAYER" },
                    { "teamOwnerRoleId23453453451092312341", "3418f935-9fa2-401b-849c-14817f1d0463", "TeamOwner", "TEAMOWNER" },
                    { "tournamentAdministratorRoleId2345334566", "396fba6b-02de-4ab9-9be4-1333ababcdc2", "TournamentAdministrator", "TOURNAMENTADMINISTRATOR" },
                    { "userRoleId23094852091092347944", "ad772ae9-5932-490e-878b-c30d1ec1ca32", "RegisteredUser", "REGISTEREDUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Nationality", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adminuser11234980723452903459235", 0, "ec367015-e77c-49d6-b079-d553663704ed", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", false, "Admin", "Male", "User", false, null, "Albanian", "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAELRZdfzrLIkBDNgzQmu7STetz+7+5Cx5hGfUVodzGKV+Z5N+A+fFJCr4lU9Mkr4VIQ==", null, false, "/images/profilepicture.jpg", "ef363e16-e9dc-49d6-8b2a-1129cc3f4f27", false, "admin" },
                    { "artmorina542225", 0, "5675fe1f-f78e-4c50-9c63-22da7ff98f33", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "artmorina@gmail.com", false, "Art", "Male", "Morina", false, null, "Albanian", "ARTMORINA@GMAIL.COM", null, "AQAAAAEAACcQAAAAEP2GL9mWgptKUjvQx5PC2+2eyX0ZknYvIdPgZq8baGVwrMLZtitA4fpagbFs/veXWA==", null, false, "/images/profilepicture4.png", "1233312d-71d3-459f-8f91-660767c829ef", false, "ArtMorina" },
                    { "defaultuser11234980723452903459235", 0, "6c9e278e-3a33-4c98-ad53-36c91530da10", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", false, "Default", "Male", "User", false, null, "Albanian", "USER@GMAIL.COM", null, "AQAAAAEAACcQAAAAEE94mQXSah8Q0XTp5gFA6JwmkjZAyJFp5GX0Krju+L7zPXrH5898eWO1FkojTnPhBw==", null, false, "/images/profilepicturedefault.jpg", "6f5f02f8-8e76-4e7a-8ea1-af88e3f5dda2", false, "defaultUser" },
                    { "flamurraci542225", 0, "aa6f2cf5-5ebc-44ed-9169-f48d7665457b", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "flamurraci@gmail.com", false, "Flamur", "Male", "Raci", false, null, "Albanian", "FLAMURRACI@GMAIL.COM", null, "AQAAAAEAACcQAAAAEDD496Tl3ft0v14M17UvvW2Us93y3mxvly/M8jUUp2afIa1Bqh3q7ZLlOri2iamriw==", null, false, "/images/profilepicture2.png", "da72f861-ce23-403c-b310-099f88261935", false, "FlamurRaci" },
                    { "kajtazbacaj542225", 0, "e91c97a3-41cd-48f9-a581-8774b91a86c0", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "kbacaj5@gmail.com", false, "Kajtaz", "Male", "Bacaj", false, null, "Albanian", "KBACAJ5@GMAIL.COM", null, "AQAAAAEAACcQAAAAEGwHnMELjXf5RTLNys4hfYpFGj7QDtZafB66y15qQ+jfagTygtWVnkEMb6EbMJHa4g==", null, false, "/images/profilepicture3.png", "34c0499f-b21c-4d23-97ee-c5cc0e95f716", false, "KajtazBacaj" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sport", "Football" },
                    { 2, "Sport", "Basketball" },
                    { 3, "Sport", "Volleyball" },
                    { 4, "Sport", "Mixed Martial Arts" },
                    { 5, "Sport", "Swimming" },
                    { 6, "Sport", "Volleyball" },
                    { 7, "Sport", "Boxing" },
                    { 8, "Sport", "Baseball" },
                    { 9, "Sport", "Golf" },
                    { 10, "Sport", "Hockey" },
                    { 11, "Sport", "Skiing" },
                    { 12, "Sport", "American Football" },
                    { 13, "Sport", "Bowling" },
                    { 14, "Sport", "Skating" },
                    { 15, "Sport", "Judo" },
                    { 16, "Sport", "Kickboxing" },
                    { 17, "Sport", "Hockey" },
                    { 18, "Sport", "Wrestrling" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "adminRoleId1293931239438254523", "adminuser11234980723452903459235" },
                    { "userRoleId23094852091092347944", "defaultuser11234980723452903459235" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "Description", "Location", "LogoUrl", "Name", "Registered_At", "ShortName", "SportId", "SportName", "TeamOwnerId", "YearFounded" },
                values: new object[,]
                {
                    { 1, "Spanish Football Team.", null, "/images/fcbarcelona.png", "FC Barcelona", new DateTime(2024, 1, 23, 1, 6, 53, 429, DateTimeKind.Utc).AddTicks(683), null, 1, "Football", "flamurraci542225", null },
                    { 2, "Italian Football Team", null, "/images/milan.png", "AC Milan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Football", "kajtazbacaj542225", null },
                    { 3, "Spanish Football Team", null, "/images/realmadrid.png", "Real Madrid", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Football", "kajtazbacaj542225", null },
                    { 4, "English Football Team", null, "/images/chelsea.png", "Chelsea FC", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "Football", "artmorina542225", null },
                    { 5, "NBA Team", null, "/images/lakers.png", "LA Lakers", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, "Basketball", "artmorina542225", null }
                });

            migrationBuilder.InsertData(
                table: "Tournaments",
                columns: new[] { "TournamentId", "Description", "ImageUrl", "Location", "Name", "Rules", "SportId", "SportName", "TournamentAdministratorId" },
                values: new object[,]
                {
                    { 1, "Europian Clubs Competition.", "/images/champions.png", null, "Champions League", null, 1, "Football", "artmorina542225" },
                    { 2, "Europian Clubs Competition.", "/images/europian.png", null, "Europa League", null, 1, "Football", "artmorina542225" },
                    { 3, "Europian Clubs Competition.", "/images/ligakosoves.png", null, "Liga e Kosoves", null, 1, "Football", "kajtazbacaj542225" },
                    { 4, "NBA Teams compete of Glory.", "/images/nbaplayoffs.png", null, "NBA Play-Offs", null, 2, "Basketball", "kajtazbacaj542225" },
                    { 5, "Europian Clubs Compete.", "/images/europeconference.png", null, "Europa Conference League", null, 1, "Football", "flamurraci542225" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "ApplicationUserId", "JerseyNumber", "Position", "Registered_At", "SportId", "TeamId" },
                values: new object[] { 1, "kajtazbacaj542225", 11, "Striker", new DateTime(2024, 1, 23, 2, 6, 53, 429, DateTimeKind.Local).AddTicks(381), 3, 4 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "ApplicationUserId", "JerseyNumber", "Position", "Registered_At", "SportId", "TeamId" },
                values: new object[] { 2, "flamurraci542225", 24, "Defender", new DateTime(2024, 1, 23, 2, 6, 53, 429, DateTimeKind.Local).AddTicks(417), 3, 4 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "ApplicationUserId", "JerseyNumber", "Position", "Registered_At", "SportId", "TeamId" },
                values: new object[] { 3, "artmorina542225", 23, "Midfielder", new DateTime(2024, 1, 23, 2, 6, 53, 429, DateTimeKind.Local).AddTicks(421), 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Teams_SportId",
                table: "Teams",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamOwnerId",
                table: "Teams",
                column: "TeamOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournament_TournamentsTournamentId",
                table: "TeamTournament",
                column: "TournamentsTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_SportId",
                table: "Tournaments",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_TournamentAdministratorId",
                table: "Tournaments",
                column: "TournamentAdministratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "TeamTournament");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
