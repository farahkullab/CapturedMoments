using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapturedMoments.Migrations
{
    /// <inheritdoc />
    public partial class SS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Sessions",
                newName: "ClientLastName");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Sessions",
                newName: "ClientFisrtName");

            migrationBuilder.RenameColumn(
                name: "Sessions",
                table: "Photographers",
                newName: "SessionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientLastName",
                table: "Sessions",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "ClientFisrtName",
                table: "Sessions",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "SessionsId",
                table: "Photographers",
                newName: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "ClientId",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
