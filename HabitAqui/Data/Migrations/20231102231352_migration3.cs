using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Locadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Gestores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Administradores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locadores_ApplicationUserId",
                table: "Locadores",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gestores_ApplicationUserId",
                table: "Gestores",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ApplicationUserId",
                table: "Clientes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_ApplicationUserId",
                table: "Administradores",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_ApplicationUserId",
                table: "Administradores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_ApplicationUserId",
                table: "Clientes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_AspNetUsers_ApplicationUserId",
                table: "Gestores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_AspNetUsers_ApplicationUserId",
                table: "Locadores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administradores_AspNetUsers_ApplicationUserId",
                table: "Administradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_ApplicationUserId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Gestores_AspNetUsers_ApplicationUserId",
                table: "Gestores");

            migrationBuilder.DropForeignKey(
                name: "FK_Locadores_AspNetUsers_ApplicationUserId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Locadores_ApplicationUserId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Gestores_ApplicationUserId",
                table: "Gestores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ApplicationUserId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Administradores_ApplicationUserId",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Gestores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Administradores");
        }
    }
}
