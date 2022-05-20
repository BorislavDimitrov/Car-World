using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorld.Data.Migrations
{
    public partial class AddCarReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReport_Cars_CarId",
                table: "CarReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarReport",
                table: "CarReport");

            migrationBuilder.RenameTable(
                name: "CarReport",
                newName: "CarReports");

            migrationBuilder.RenameIndex(
                name: "IX_CarReport_CarId",
                table: "CarReports",
                newName: "IX_CarReports_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarReports",
                table: "CarReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReports_Cars_CarId",
                table: "CarReports",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReports_Cars_CarId",
                table: "CarReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarReports",
                table: "CarReports");

            migrationBuilder.RenameTable(
                name: "CarReports",
                newName: "CarReport");

            migrationBuilder.RenameIndex(
                name: "IX_CarReports_CarId",
                table: "CarReport",
                newName: "IX_CarReport_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarReport",
                table: "CarReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReport_Cars_CarId",
                table: "CarReport",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
