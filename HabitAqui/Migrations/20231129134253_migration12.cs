using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioId",
                table: "EntregarArrendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioId",
                table: "ReceberArrendamento");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "ReceberArrendamento",
                newName: "FuncionarioRecebeuId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceberArrendamento_FuncionarioId",
                table: "ReceberArrendamento",
                newName: "IX_ReceberArrendamento_FuncionarioRecebeuId");

            migrationBuilder.RenameColumn(
                name: "FuncionarioId",
                table: "EntregarArrendamento",
                newName: "FuncionarioEntregaId");

            migrationBuilder.RenameIndex(
                name: "IX_EntregarArrendamento_FuncionarioId",
                table: "EntregarArrendamento",
                newName: "IX_EntregarArrendamento_FuncionarioEntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamento",
                column: "FuncionarioEntregaId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamento",
                column: "FuncionarioRecebeuId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamento");

            migrationBuilder.RenameColumn(
                name: "FuncionarioRecebeuId",
                table: "ReceberArrendamento",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceberArrendamento_FuncionarioRecebeuId",
                table: "ReceberArrendamento",
                newName: "IX_ReceberArrendamento_FuncionarioId");

            migrationBuilder.RenameColumn(
                name: "FuncionarioEntregaId",
                table: "EntregarArrendamento",
                newName: "FuncionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_EntregarArrendamento_FuncionarioEntregaId",
                table: "EntregarArrendamento",
                newName: "IX_EntregarArrendamento_FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioId",
                table: "EntregarArrendamento",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioId",
                table: "ReceberArrendamento",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
