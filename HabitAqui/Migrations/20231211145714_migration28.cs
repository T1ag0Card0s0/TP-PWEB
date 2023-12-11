using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration28 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceberArrendamento",
                table: "ReceberArrendamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntregarArrendamento",
                table: "EntregarArrendamento");

            migrationBuilder.RenameTable(
                name: "ReceberArrendamento",
                newName: "ReceberArrendamentos");

            migrationBuilder.RenameTable(
                name: "EntregarArrendamento",
                newName: "EntregarArrendamentos");

            migrationBuilder.RenameIndex(
                name: "IX_ReceberArrendamento_FuncionarioRecebeuId",
                table: "ReceberArrendamentos",
                newName: "IX_ReceberArrendamentos_FuncionarioRecebeuId");

            migrationBuilder.RenameIndex(
                name: "IX_EntregarArrendamento_FuncionarioEntregaId",
                table: "EntregarArrendamentos",
                newName: "IX_EntregarArrendamentos_FuncionarioEntregaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceberArrendamentos",
                table: "ReceberArrendamentos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntregarArrendamentos",
                table: "EntregarArrendamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamentos_EntregarArrendamentoId",
                table: "Arrendamentos",
                column: "EntregarArrendamentoId",
                principalTable: "EntregarArrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamentos_ReceberArrendamentoId",
                table: "Arrendamentos",
                column: "ReceberArrendamentoId",
                principalTable: "ReceberArrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregarArrendamentos_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamentos",
                column: "FuncionarioEntregaId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_EntregarArrendamentos_EntregarArrendamentoId",
                table: "Equipamentos",
                column: "EntregarArrendamentoId",
                principalTable: "EntregarArrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_ReceberArrendamentos_ReceberArrendamentoId",
                table: "Equipamentos",
                column: "ReceberArrendamentoId",
                principalTable: "ReceberArrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceberArrendamentos_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamentos",
                column: "FuncionarioRecebeuId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamentos_EntregarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamentos_ReceberArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregarArrendamentos_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_EntregarArrendamentos_EntregarArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_ReceberArrendamentos_ReceberArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceberArrendamentos_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceberArrendamentos",
                table: "ReceberArrendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntregarArrendamentos",
                table: "EntregarArrendamentos");

            migrationBuilder.RenameTable(
                name: "ReceberArrendamentos",
                newName: "ReceberArrendamento");

            migrationBuilder.RenameTable(
                name: "EntregarArrendamentos",
                newName: "EntregarArrendamento");

            migrationBuilder.RenameIndex(
                name: "IX_ReceberArrendamentos_FuncionarioRecebeuId",
                table: "ReceberArrendamento",
                newName: "IX_ReceberArrendamento_FuncionarioRecebeuId");

            migrationBuilder.RenameIndex(
                name: "IX_EntregarArrendamentos_FuncionarioEntregaId",
                table: "EntregarArrendamento",
                newName: "IX_EntregarArrendamento_FuncionarioEntregaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceberArrendamento",
                table: "ReceberArrendamento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntregarArrendamento",
                table: "EntregarArrendamento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Arrendamentos",
                column: "EntregarArrendamentoId",
                principalTable: "EntregarArrendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Arrendamentos",
                column: "ReceberArrendamentoId",
                principalTable: "ReceberArrendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregarArrendamento_Funcionarios_FuncionarioEntregaId",
                table: "EntregarArrendamento",
                column: "FuncionarioEntregaId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Equipamentos",
                column: "EntregarArrendamentoId",
                principalTable: "EntregarArrendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Equipamentos",
                column: "ReceberArrendamentoId",
                principalTable: "ReceberArrendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceberArrendamento_Funcionarios_FuncionarioRecebeuId",
                table: "ReceberArrendamento",
                column: "FuncionarioRecebeuId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
