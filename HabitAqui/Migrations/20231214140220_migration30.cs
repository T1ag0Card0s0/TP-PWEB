using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danos");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Habitacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habitacoes_ClienteId",
                table: "Habitacoes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitacoes_Clientes_ClienteId",
                table: "Habitacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitacoes_Clientes_ClienteId",
                table: "Habitacoes");

            migrationBuilder.DropIndex(
                name: "IX_Habitacoes_ClienteId",
                table: "Habitacoes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Habitacoes");

            migrationBuilder.CreateTable(
                name: "Danos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fomat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danos", x => x.Id);
                });
        }
    }
}
