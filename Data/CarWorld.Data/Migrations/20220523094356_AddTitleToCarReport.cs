using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorld.Data.Migrations
{
    public partial class AddTitleToCarReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CarReports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CarReports");
        }
    }
}
