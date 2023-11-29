using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Arrendamentos");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoEstado",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipamentoEstado",
                table: "Equipamentos");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Arrendamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
