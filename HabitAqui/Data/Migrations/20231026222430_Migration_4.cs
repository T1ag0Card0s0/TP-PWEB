using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Data.Migrations
{
    public partial class Migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrador_1",
                table: "Administrador_1");

            migrationBuilder.RenameTable(
                name: "Administrador_1",
                newName: "Administrador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador");

            migrationBuilder.RenameTable(
                name: "Administrador",
                newName: "Administrador_1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrador_1",
                table: "Administrador_1",
                column: "Id");
        }
    }
}
