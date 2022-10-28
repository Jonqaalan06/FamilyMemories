using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMemories.Migrations
{
    public partial class AddShortDescriptioncolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Images");
        }
    }
}
