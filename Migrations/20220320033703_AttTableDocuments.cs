using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cpfSupera.Migrations
{
    public partial class AttTableDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cpfModel",
                table: "cpfModel");

            migrationBuilder.RenameTable(
                name: "cpfModel",
                newName: "tb_document");

            migrationBuilder.RenameColumn(
                name: "Register",
                table: "tb_document",
                newName: "register");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_document",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "tb_document",
                newName: "document");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_document",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_document",
                table: "tb_document",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_document",
                table: "tb_document");

            migrationBuilder.RenameTable(
                name: "tb_document",
                newName: "cpfModel");

            migrationBuilder.RenameColumn(
                name: "register",
                table: "cpfModel",
                newName: "Register");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "cpfModel",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "document",
                table: "cpfModel",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cpfModel",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cpfModel",
                table: "cpfModel",
                column: "Id");
        }
    }
}
