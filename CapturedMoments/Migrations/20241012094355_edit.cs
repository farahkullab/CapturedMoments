using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapturedMoments.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profileImgUrl",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "ClientImgUrl",
                table: "feedbacks");

            migrationBuilder.RenameColumn(
                name: "bookingNum",
                table: "Sections",
                newName: "photographerId");

            migrationBuilder.RenameColumn(
                name: "Portfolio",
                table: "Photographers",
                newName: "SocialMediaURL");

            migrationBuilder.RenameColumn(
                name: "PhotograperBusinessName",
                table: "Photographers",
                newName: "PhotograperName");

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreationDate",
                table: "Photographers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Photographers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Photographers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreationDate",
                table: "Galleries",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Galleries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Galleries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Photographers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Galleries");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Galleries");

            migrationBuilder.RenameColumn(
                name: "photographerId",
                table: "Sections",
                newName: "bookingNum");

            migrationBuilder.RenameColumn(
                name: "SocialMediaURL",
                table: "Photographers",
                newName: "Portfolio");

            migrationBuilder.RenameColumn(
                name: "PhotograperName",
                table: "Photographers",
                newName: "PhotograperBusinessName");

            migrationBuilder.AddColumn<string>(
                name: "profileImgUrl",
                table: "Sections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientImgUrl",
                table: "feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
