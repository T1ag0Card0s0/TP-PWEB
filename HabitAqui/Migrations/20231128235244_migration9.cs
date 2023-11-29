using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoReceberId",
                table: "Equipamentos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Existencia",
                table: "Equipamentos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReceberId",
                table: "Danos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReceberId",
                table: "Arrendamentos",
                type: "int",
                nullable: true);

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
                name: "IX_Equipamentos_EstadoReceberId",
                table: "Equipamentos",
                column: "EstadoReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_Danos_EstadoReceberId",
                table: "Danos",
                column: "EstadoReceberId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrendamentos_EstadoReceberId",
                table: "Arrendamentos",
                column: "EstadoReceberId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EstadoReceber_EstadoReceberId",
                table: "Arrendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Danos_EstadoReceber_EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_EstadoReceber_EstadoReceberId",
                table: "Equipamentos");

            migrationBuilder.DropTable(
                name: "EstadoReceber");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_EstadoReceberId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Danos_EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropIndex(
                name: "IX_Arrendamentos_EstadoReceberId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "EstadoReceberId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "EstadoReceberId",
                table: "Danos");

            migrationBuilder.DropColumn(
                name: "EstadoReceberId",
                table: "Arrendamentos");
        }
    }
}
