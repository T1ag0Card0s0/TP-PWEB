using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class identity : Migration
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Locadores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Gestores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Administradores",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Locadores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Gestores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Funcionarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
            
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UtilizadorId1",
                table: "Administradores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administradores_AspNetUsers_UtilizadorId1",
                table: "Administradores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_UtilizadorId1",
                table: "Clientes",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_AspNetUsers_UtilizadorId1",
                table: "Funcionarios",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gestores_AspNetUsers_UtilizadorId1",
                table: "Gestores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_AspNetUsers_UtilizadorId1",
                table: "Locadores",
                column: "UtilizadorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
