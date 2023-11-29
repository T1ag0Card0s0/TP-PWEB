using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntragarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "Arrendamentos");

            migrationBuilder.RenameColumn(
                name: "EntragarArrendamentoId",
                table: "Arrendamentos",
                newName: "EntregarArrendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Arrendamentos_EntragarArrendamentoId",
                table: "Arrendamentos",
                newName: "IX_Arrendamentos_EntregarArrendamentoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "EntregarArrendamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Arrendamentos",
                column: "EntregarArrendamentoId",
                principalTable: "EntregarArrendamento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntregarArrendamentoId",
                table: "Arrendamentos");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "EntregarArrendamento");

            migrationBuilder.RenameColumn(
                name: "EntregarArrendamentoId",
                table: "Arrendamentos",
                newName: "EntragarArrendamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Arrendamentos_EntregarArrendamentoId",
                table: "Arrendamentos",
                newName: "IX_Arrendamentos_EntragarArrendamentoId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "Arrendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Arrendamentos_EntregarArrendamento_EntragarArrendamentoId",
                table: "Arrendamentos",
                column: "EntragarArrendamentoId",
                principalTable: "EntregarArrendamento",
                principalColumn: "Id");
        }
    }
}
