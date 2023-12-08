using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
