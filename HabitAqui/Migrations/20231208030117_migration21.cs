using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem");

            migrationBuilder.RenameTable(
                name: "Imagem",
                newName: "Imagens");

            migrationBuilder.RenameIndex(
                name: "IX_Imagem_ArrendamentoId",
                table: "Imagens",
                newName: "IX_Imagens_ArrendamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens",
                column: "Id");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Imagens",
                table: "Imagens");

            migrationBuilder.RenameTable(
                name: "Imagens",
                newName: "Imagem");

            migrationBuilder.RenameIndex(
                name: "IX_Imagens_ArrendamentoId",
                table: "Imagem",
                newName: "IX_Imagem_ArrendamentoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Imagem",
                table: "Imagem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagem_Arrendamentos_ArrendamentoId",
                table: "Imagem",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");
        }
    }
}
