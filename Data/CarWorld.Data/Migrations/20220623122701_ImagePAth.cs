using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorld.Data.Migrations
{
    public partial class ImagePAth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Categories",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Categories",
                newName: "ImageUrl");
        }
    }
}
