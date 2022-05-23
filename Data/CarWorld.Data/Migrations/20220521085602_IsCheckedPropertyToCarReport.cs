using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorld.Data.Migrations
{
    public partial class IsCheckedPropertyToCarReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "CarReports",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "CarReports");
        }
    }
}
