using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Data.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacao_Categoria_CategoriaId",
                table: "Habitacao");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Habitacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacao_Categoria_CategoriaId",
                table: "Habitacao",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacao_Categoria_CategoriaId",
                table: "Habitacao");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Habitacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacao_Categoria_CategoriaId",
                table: "Habitacao",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId");
        }
    }
}
