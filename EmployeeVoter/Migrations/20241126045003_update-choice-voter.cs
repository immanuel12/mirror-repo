using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeVoter.Migrations
{
    /// <inheritdoc />
    public partial class updatechoicevoter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Elections",
                table: "Elections");

            migrationBuilder.RenameTable(
                name: "Elections",
                newName: "ChoiceVoter");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChoiceVoter",
                table: "ChoiceVoter",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChoiceVoter",
                table: "ChoiceVoter");

            migrationBuilder.RenameTable(
                name: "ChoiceVoter",
                newName: "Elections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Elections",
                table: "Elections",
                column: "Id");
        }
    }
}
