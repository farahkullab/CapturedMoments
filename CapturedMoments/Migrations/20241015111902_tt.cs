using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapturedMoments.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotographerId",
                table: "feedbacks",
                newName: "PhotographerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotographerName",
                table: "feedbacks",
                newName: "PhotographerId");
        }
    }
}
