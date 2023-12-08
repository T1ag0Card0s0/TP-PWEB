using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration26 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens");

            migrationBuilder.AlterColumn<int>(
                name: "ArrendamentoId",
                table: "Imagens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens");

            migrationBuilder.AlterColumn<int>(
                name: "ArrendamentoId",
                table: "Imagens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");
        }
    }
}
