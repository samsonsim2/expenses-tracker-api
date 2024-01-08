using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace expenses_tracker_api.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "createdAt", "email", "firstName", "imageUrl", "lastName", "updatedAt" },
                values: new object[] { 1, null, "samsonsim@gmail.com", "samson", null, "sim", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "createdAt", "email", "firstName", "imageUrl", "lastName", "updatedAt" },
                values: new object[] { 2, null, "testuser@gmail.com", "test", null, "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
