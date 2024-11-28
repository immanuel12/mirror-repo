using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeVoter.Migrations
{
    /// <inheritdoc />
    public partial class addingchoicevoter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Choice = table.Column<int>(type: "int", nullable: false),
                    Updated_at = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_voter = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elections");
        }
    }
}
