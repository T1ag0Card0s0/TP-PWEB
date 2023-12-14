using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HabitAqui.Migrations
{
    public partial class migration32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locadores_AspNetUsers_ApplicationUserId",
                table: "Locadores");

            migrationBuilder.DropIndex(
                name: "IX_Locadores_ApplicationUserId",
                table: "Locadores");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Locadores");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Locadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Locadores");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Locadores",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locadores_ApplicationUserId",
                table: "Locadores",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locadores_AspNetUsers_ApplicationUserId",
                table: "Locadores",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
