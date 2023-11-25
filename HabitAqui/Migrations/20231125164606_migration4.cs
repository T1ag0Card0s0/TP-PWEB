using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Equipamentos");

            migrationBuilder.RenameColumn(
                name: "DescricaoEstado",
                table: "Equipamentos",
                newName: "Descricao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Equipamentos",
                newName: "DescricaoEstado");

            migrationBuilder.AddColumn<bool>(
                name: "Existencia",
                table: "Equipamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
