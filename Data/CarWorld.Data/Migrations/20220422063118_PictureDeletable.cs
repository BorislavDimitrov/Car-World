using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorld.Data.Migrations
{
    public partial class PictureDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Pictures",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pictures");
        }
    }
}
