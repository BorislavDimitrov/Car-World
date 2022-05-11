#nullable disable

namespace CarWorld.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameCityToRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "Regions");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_IsDeleted",
                table: "Regions",
                newName: "IX_Regions_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Regions_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Regions_CityId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_IsDeleted",
                table: "Cities",
                newName: "IX_Cities_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
