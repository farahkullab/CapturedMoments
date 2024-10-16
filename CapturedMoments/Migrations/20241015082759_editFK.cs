using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapturedMoments.Migrations
{
    /// <inheritdoc />
    public partial class editFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Galleries_CategoryId",
                table: "Galleries",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Galleries_PhotographerId",
                table: "Galleries",
                column: "PhotographerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Categories_CategoryId",
                table: "Galleries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Photographers_PhotographerId",
                table: "Galleries",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "PhotographerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Categories_CategoryId",
                table: "Galleries");

            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Photographers_PhotographerId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_CategoryId",
                table: "Galleries");

            migrationBuilder.DropIndex(
                name: "IX_Galleries_PhotographerId",
                table: "Galleries");
        }
    }
}
