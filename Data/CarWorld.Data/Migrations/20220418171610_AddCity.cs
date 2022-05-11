#nullable disable

namespace CarWorld.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Regions_CityId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cars",
                newName: "RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CityId",
                table: "Cars",
                newName: "IX_Cars_RegionId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Regions_RegionId",
                table: "Cars",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Regions_RegionId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "RegionId",
                table: "Cars",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_RegionId",
                table: "Cars",
                newName: "IX_Cars_CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Regions_CityId",
                table: "Cars",
                column: "CityId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
