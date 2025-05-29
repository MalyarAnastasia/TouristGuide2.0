using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TouristGuide.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreCitiesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoatOfArmsUrl",
                table: "Cities",
                newName: "CoatUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoatUrl",
                table: "Cities",
                newName: "CoatOfArmsUrl");
        }
    }
}
