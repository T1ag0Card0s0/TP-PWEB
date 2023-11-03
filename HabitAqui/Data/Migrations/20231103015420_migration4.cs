using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Gestores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ApplicationUserId",
                table: "Funcionarios",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_ApplicationUserId",
                table: "Funcionarios",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_AspNetUsers_ApplicationUserId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_ApplicationUserId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Funcionarios");
        }
    }
}
