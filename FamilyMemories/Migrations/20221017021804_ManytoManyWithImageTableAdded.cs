using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMemories.Migrations
{
    public partial class ManytoManyWithImageTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMembers_Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMembers_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Images_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMembers_Images_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_ImageId",
                table: "FamilyMembers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_Images_FamilyMemberId",
                table: "FamilyMembers_Images",
                column: "FamilyMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_Images_ImageId",
                table: "FamilyMembers_Images",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Images_ImageId",
                table: "FamilyMembers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Images_ImageId",
                table: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "FamilyMembers_Images");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_ImageId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "FamilyMembers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "FamilyMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
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
