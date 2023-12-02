using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacoesHabitacao_Habitacoes_HabitacaoId",
                table: "AvaliacoesHabitacao");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacoesHabitacao_Habitacoes_HabitacaoId",
                table: "AvaliacoesHabitacao",
                column: "HabitacaoId",
                principalTable: "Habitacoes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacoesHabitacao_Habitacoes_HabitacaoId",
                table: "AvaliacoesHabitacao");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacoesHabitacao_Habitacoes_HabitacaoId",
                table: "AvaliacoesHabitacao",
                column: "HabitacaoId",
                principalTable: "Habitacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
