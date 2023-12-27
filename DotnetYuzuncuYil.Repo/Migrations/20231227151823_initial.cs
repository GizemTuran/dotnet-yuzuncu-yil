using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetYuzuncuYil.Repo.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "TeamName", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(3189), "Development", null },
                    { 2, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(3202), "Sales", null },
                    { 3, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(3205), "Marketing", null },
                    { 4, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(3207), "HR", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Password", "TeamId", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(4030), "buse@gmail.com", "123456", 1, null, "buse" },
                    { 2, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(4036), "elnur@gmail.com", "455678", 2, null, "elnur" },
                    { 3, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(4038), "seher@gmail.com", "789456", 3, null, "seher" },
                    { 4, new DateTime(2023, 12, 27, 18, 18, 23, 634, DateTimeKind.Local).AddTicks(4039), "gizem@gmail.com", "874569", 4, null, "gizem" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "FirstName", "LastName", "NickName", "UserId" },
                values: new object[,]
                {
                    { 1, "Buse", "Sezer", "bus", 1 },
                    { 2, "Elnur", "Akkurt", "eln", 2 },
                    { 3, "Seher", "Tosun", "b12", 3 },
                    { 4, "Gizem", "Turan", "sherlock", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
