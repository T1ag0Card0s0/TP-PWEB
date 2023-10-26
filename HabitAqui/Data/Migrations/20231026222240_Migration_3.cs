using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Data.Migrations
{
    public partial class Migration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "Locadores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GestorId",
                table: "Estados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Administrador_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gestores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gestores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locadores_GestorId",
                table: "Locadores",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_GestorId",
                table: "Estados",
                column: "GestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estados_Gestores_GestorId",
                table: "Estados",
                column: "GestorId",
                principalTable: "Gestores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_Gestores_GestorId",
                table: "Locadores",
                column: "GestorId",
                principalTable: "Gestores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estados_Gestores_GestorId",
                table: "Estados");

            migrationBuilder.DropForeignKey(
                name: "FK_Locadores_Gestores_GestorId",
                table: "Locadores");

            migrationBuilder.DropTable(
                name: "Administrador_1");

            migrationBuilder.DropTable(
                name: "Gestores");

            migrationBuilder.DropIndex(
                name: "IX_Locadores_GestorId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Estados_GestorId",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "GestorId",
                table: "Estados");
        }
    }
}
