using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMemories.Migrations
{
    public partial class UpdateFamilyMemberTableWithRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ChildrenIds",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiblingIds",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpouseId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildrenIds",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "SiblingIds",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "SpouseId",
                table: "FamilyMembers");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
