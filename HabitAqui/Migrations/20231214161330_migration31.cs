using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Gestores_GestorId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_GestorId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Funcionarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "Funcionarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_GestorId",
                table: "Funcionarios",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Gestores_GestorId",
                table: "Funcionarios",
                column: "GestorId",
                principalTable: "Gestores",
                principalColumn: "GestorId");
        }
    }
}
