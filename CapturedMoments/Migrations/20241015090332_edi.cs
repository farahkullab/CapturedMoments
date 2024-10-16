using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapturedMoments.Migrations
{
    /// <inheritdoc />
    public partial class edi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "photographerImgUrl",
                table: "Sections");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Sections");

            migrationBuilder.AddColumn<string>(
                name: "photographerImgUrl",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
