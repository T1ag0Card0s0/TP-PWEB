using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_AspNetUsers_UtilizadorId1",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_UtilizadorId1",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AspNetUsers_UtilizadorId1",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_AspNetUsers_UtilizadorId1",
                table: "Gestores");

            migrationBuilder.DropForeignKey(
                name: "FK_Locadores_AspNetUsers_UtilizadorId1",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Locadores_UtilizadorId1",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Gestores_UtilizadorId1",
                table: "Gestores");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_UtilizadorId1",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UtilizadorId1",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_UtilizadorId1",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId1",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId1",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UtilizadorId1",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UtilizadorId1",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UtilizadorId",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "UtilizadorId1",
                table: "Administradores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Locadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId1",
                table: "Locadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Gestores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId1",
                table: "Gestores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId1",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId1",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UtilizadorId",
                table: "Administradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UtilizadorId1",
                table: "Administradores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locadores_UtilizadorId1",
                table: "Locadores",
                column: "UtilizadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_UtilizadorId1",
                table: "Gestores",
                column: "UtilizadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UtilizadorId1",
                table: "Funcionarios",
                column: "UtilizadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UtilizadorId1",
                table: "Clientes",
                column: "UtilizadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_UtilizadorId1",
                table: "Administradores",
                column: "UtilizadorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_UtilizadorId1",
                table: "Administradores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_UtilizadorId1",
                table: "Clientes",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_UtilizadorId1",
                table: "Funcionarios",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_AspNetUsers_UtilizadorId1",
                table: "Gestores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_AspNetUsers_UtilizadorId1",
                table: "Locadores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
