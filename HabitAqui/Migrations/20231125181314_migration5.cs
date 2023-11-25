using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danos_Estados_EstadoId",
                table: "Danos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Arrendamentos_ArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Estados_EstadoId",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_ArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_EstadoId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Danos_EstadoId",
                table: "Danos");

            migrationBuilder.DropColumn(
                name: "ArrendamentoId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Danos");

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

            migrationBuilder.CreateIndex(
                name: "IX_ArrendamentoEquipamento_EquipamentosOpcionaisId",
                table: "ArrendamentoEquipamento",
                column: "EquipamentosOpcionaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrendamentoEquipamento");

            migrationBuilder.AddColumn<int>(
                name: "ArrendamentoId",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Danos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrendamentoId = table.Column<int>(type: "int", nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Arrendamentos_ArrendamentoId",
                        column: x => x.ArrendamentoId,
                        principalTable: "Arrendamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Estados_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ArrendamentoId",
                table: "Equipamentos",
                column: "ArrendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_EstadoId",
                table: "Equipamentos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Danos_EstadoId",
                table: "Danos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_ArrendamentoId",
                table: "Estados",
                column: "ArrendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_FuncionarioId",
                table: "Estados",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Danos_Estados_EstadoId",
                table: "Danos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Arrendamentos_ArrendamentoId",
                table: "Equipamentos",
                column: "ArrendamentoId",
                principalTable: "Arrendamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Estados_EstadoId",
                table: "Equipamentos",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id");
        }
    }
}
