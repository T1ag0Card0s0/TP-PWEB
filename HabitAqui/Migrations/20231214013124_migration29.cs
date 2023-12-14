using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Administradores_AdministradorId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Locadores_Administradores_AdministradorId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Locadores_AdministradorId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_AdministradorId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "AdministradorId",
                table: "Categorias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Locadores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdministradorId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locadores_AdministradorId",
                table: "Locadores",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_AdministradorId",
                table: "Categorias",
                column: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Administradores_AdministradorId",
                table: "Categorias",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "AdministradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_Administradores_AdministradorId",
                table: "Locadores",
                column: "AdministradorId",
                principalTable: "Administradores",
                principalColumn: "AdministradorId");
        }
    }
}
