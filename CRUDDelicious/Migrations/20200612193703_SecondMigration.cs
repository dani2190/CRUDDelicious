using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDDelicious.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Lizards",
                table: "Lizards");

            migrationBuilder.RenameTable(
                name: "Lizards",
                newName: "Dishes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DiSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Lizards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lizards",
                table: "Lizards",
                column: "DiSId");
        }
    }
}
