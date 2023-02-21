using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyMemories.Migrations
{
    public partial class AddingDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "FamilyMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMember_Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyMemberId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMember_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Documents_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyMember_Documents_FamilyMembers_FamilyMemberId",
                        column: x => x.FamilyMemberId,
                        principalTable: "FamilyMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_DocumentId",
                table: "FamilyMembers",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_Documents_DocumentId",
                table: "FamilyMember_Documents",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_Documents_FamilyMemberId",
                table: "FamilyMember_Documents",
                column: "FamilyMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_Documents_DocumentId",
                table: "FamilyMembers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_Documents_DocumentId",
                table: "FamilyMembers");

            migrationBuilder.DropTable(
                name: "FamilyMember_Documents");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_DocumentId",
                table: "FamilyMembers");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "FamilyMembers");
        }
    }
}
