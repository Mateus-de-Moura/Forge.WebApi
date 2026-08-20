using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forge.WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CreatedAt", "Email", "Name", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpirationTime", "Surname", "UserName" },
                values: new object[] { new Guid("c3d2251f-1e0b-42b6-8868-75d03046460c"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "$2a$11$kgueTQbW2exSJwFqWxQ.h.cFK5l5WArN8DdGWCLS1UZ849lop2C2m", "$2a$11$kgueTQbW2exSJwFqWxQ.h.", "vMVEc5sypGQDpoqFWtmXOuVfPwjzEo9EuorBukiH/WbE2EYvAeGJxaCBGnwgRv7sSV2/6dfX220TjC4quGC/MexPfZiL/U6YPferYZRGcPz30fFg4jzO4Y1wTbXSvV2ta5j8nlAhdvGDT0dTW42RgTmrzmKun4B0nPCV3AIpupQ=", new DateTime(2027, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
