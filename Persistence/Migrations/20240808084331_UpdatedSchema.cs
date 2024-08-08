using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoundedLocationId",
                table: "Teams",
                newName: "FoundedCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_FoundedLocationId",
                table: "Teams",
                newName: "IX_Teams_FoundedCountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoundedCountryId",
                table: "Teams",
                newName: "FoundedLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_FoundedCountryId",
                table: "Teams",
                newName: "IX_Teams_FoundedLocationId");
        }
    }
}
