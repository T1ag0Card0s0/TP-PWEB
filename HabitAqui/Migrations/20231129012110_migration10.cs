using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EstadoReceber_EstadoReceberId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_Funcionarios_FuncionarioEntregaId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Danos_Arrendamentos_ArrendamentoId",
                table: "Danos");

            migrationBuilder.DropForeignKey(
                name: "FK_Danos_EstadoReceber_EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_EstadoReceber_EstadoReceberId",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "ArrendamentoEquipamento");

            migrationBuilder.DropTable(
                name: "EstadoReceber");

            migrationBuilder.DropIndex(
                name: "IX_Danos_ArrendamentoId",
                table: "Danos");

            migrationBuilder.DropIndex(
                name: "IX_Danos_EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamentos_FuncionarioEntregaId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "ArrendamentoId",
                table: "Danos");

            migrationBuilder.DropColumn(
                name: "EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropColumn(
                name: "FuncionarioEntregaId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Arrendamentos");

            migrationBuilder.RenameColumn(
                name: "EstadoReceberId",
                table: "Equipamentos",
                newName: "ReceberArrendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamentos_EstadoReceberId",
                table: "Equipamentos",
                newName: "IX_Equipamentos_ReceberArrendamentoId");

            migrationBuilder.RenameColumn(
                name: "EstadoReceberId",
                table: "Arrendamentos",
                newName: "ReceberArrendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Arrendamentos_EstadoReceberId",
                table: "Arrendamentos",
                newName: "IX_Arrendamentos_ReceberArrendamentoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EntregarArrendamentoId",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntragarArrendamentoId",
                table: "Arrendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoId",
                table: "Arrendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntregarArrendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Danos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregarArrendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntregarArrendamento_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceberArrendamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Danos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceberArrendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceberArrendamento_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_EntregarArrendamentoId",
                table: "Equipamentos",
                column: "EntregarArrendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_EntragarArrendamentoId",
                table: "Arrendamentos",
                column: "EntragarArrendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_EquipamentoId",
                table: "Arrendamentos",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregarArrendamento_FuncionarioId",
                table: "EntregarArrendamento",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceberArrendamento_FuncionarioId",
                table: "ReceberArrendamento",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntragarArrendamentoId",
                table: "Arrendamentos",
                column: "EntragarArrendamentoId",
                principalTable: "EntregarArrendamento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_Equipamentos_EquipamentoId",
                table: "Arrendamentos",
                column: "EquipamentoId",
                principalTable: "Equipamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Arrendamentos",
                column: "ReceberArrendamentoId",
                principalTable: "ReceberArrendamento",
                principalColumn: "Id");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntragarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_Equipamentos_EquipamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_ReceberArrendamento_ReceberArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "EntregarArrendamento");

            migrationBuilder.DropTable(
                name: "ReceberArrendamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_EntregarArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamentos_EntragarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamentos_EquipamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "EntregarArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "EntragarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "EquipamentoId",
                table: "Arrendamentos");

            migrationBuilder.RenameColumn(
                name: "ReceberArrendamentoId",
                table: "Equipamentos",
                newName: "EstadoReceberId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamentos_ReceberArrendamentoId",
                table: "Equipamentos",
                newName: "IX_Equipamentos_EstadoReceberId");

            migrationBuilder.RenameColumn(
                name: "ReceberArrendamentoId",
                table: "Arrendamentos",
                newName: "EstadoReceberId");

            migrationBuilder.RenameIndex(
                name: "IX_Arrendamentos_ReceberArrendamentoId",
                table: "Arrendamentos",
                newName: "IX_Arrendamentos_EstadoReceberId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Equipamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArrendamentoId",
                table: "Danos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReceberId",
                table: "Danos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioEntregaId",
                table: "Arrendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Arrendamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ArrendamentoEquipamento",
                columns: table => new
                {
                    ArrendamentosId = table.Column<int>(type: "int", nullable: false),
                    EquipamentosOpcionaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrendamentoEquipamento", x => new { x.ArrendamentosId, x.EquipamentosOpcionaisId });
                    table.ForeignKey(
                        name: "FK_ArrendamentoEquipamento_Arrendamentos_ArrendamentosId",
                        column: x => x.ArrendamentosId,
                        principalTable: "Arrendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArrendamentoEquipamento_Equipamentos_EquipamentosOpcionaisId",
                        column: x => x.EquipamentosOpcionaisId,
                        principalTable: "Equipamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstadoReceber",
                columns: table => new
                {
                    EstadoReceberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoReceber", x => x.EstadoReceberId);
                    table.ForeignKey(
                        name: "FK_EstadoReceber_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Danos_ArrendamentoId",
                table: "Danos",
                column: "ArrendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Danos_EstadoReceberId",
                table: "Danos",
                column: "EstadoReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_FuncionarioEntregaId",
                table: "Arrendamentos",
                column: "FuncionarioEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrendamentoEquipamento_EquipamentosOpcionaisId",
                table: "ArrendamentoEquipamento",
                column: "EquipamentosOpcionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoReceber_FuncionarioId",
                table: "EstadoReceber",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EstadoReceber_EstadoReceberId",
                table: "Arrendamentos",
                column: "EstadoReceberId",
                principalTable: "EstadoReceber",
                principalColumn: "EstadoReceberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_Funcionarios_FuncionarioEntregaId",
                table: "Arrendamentos",
                column: "FuncionarioEntregaId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Danos_Arrendamentos_ArrendamentoId",
                table: "Danos",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Danos_EstadoReceber_EstadoReceberId",
                table: "Danos",
                column: "EstadoReceberId",
                principalTable: "EstadoReceber",
                principalColumn: "EstadoReceberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_EstadoReceber_EstadoReceberId",
                table: "Equipamentos",
                column: "EstadoReceberId",
                principalTable: "EstadoReceber",
                principalColumn: "EstadoReceberId");
        }
    }
}
