using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagens_Arrendamentos_ArrendamentoId",
                table: "Imagens",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
