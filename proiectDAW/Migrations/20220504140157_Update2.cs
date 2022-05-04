using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDAW.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editor_Authors_AuthorId",
                table: "Editor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editor",
                table: "Editor");

            migrationBuilder.RenameTable(
                name: "Editor",
                newName: "Editors");

            migrationBuilder.RenameIndex(
                name: "IX_Editor_AuthorId",
                table: "Editors",
                newName: "IX_Editors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editors",
                table: "Editors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Editors_Authors_AuthorId",
                table: "Editors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Editors_Authors_AuthorId",
                table: "Editors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Editors",
                table: "Editors");

            migrationBuilder.RenameTable(
                name: "Editors",
                newName: "Editor");

            migrationBuilder.RenameIndex(
                name: "IX_Editors_AuthorId",
                table: "Editor",
                newName: "IX_Editor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Editor",
                table: "Editor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Editor_Authors_AuthorId",
                table: "Editor",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
