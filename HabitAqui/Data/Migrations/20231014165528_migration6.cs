using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Data.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_fim",
                table: "Habitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_inicio",
                table: "Habitacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeriodoMinimo",
                table: "Habitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_fim",
                table: "Habitacao");

            migrationBuilder.DropColumn(
                name: "Data_inicio",
                table: "Habitacao");

            migrationBuilder.DropColumn(
                name: "PeriodoMinimo",
                table: "Habitacao");
        }
    }
}
