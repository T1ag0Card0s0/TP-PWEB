using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacoes_Categorias_CategoriaId",
                table: "Habitacoes");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Habitacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacoes_Categorias_CategoriaId",
                table: "Habitacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacoes_Categorias_CategoriaId",
                table: "Habitacoes");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Habitacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacoes_Categorias_CategoriaId",
                table: "Habitacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "CategoriaId");
        }
    }
}
