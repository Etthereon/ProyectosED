using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CanchaEspacios_Entrenadores_Entrenadorid",
                table: "CanchaEspacios");

            migrationBuilder.DropIndex(
                name: "IX_CanchaEspacios_Entrenadorid",
                table: "CanchaEspacios");

            migrationBuilder.DropColumn(
                name: "Entrenadorid",
                table: "CanchaEspacios");

            migrationBuilder.AlterColumn<string>(
                name: "Medidas",
                table: "CanchaEspacios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Medidas",
                table: "CanchaEspacios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "Entrenadorid",
                table: "CanchaEspacios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CanchaEspacios_Entrenadorid",
                table: "CanchaEspacios",
                column: "Entrenadorid");

            migrationBuilder.AddForeignKey(
                name: "FK_CanchaEspacios_Entrenadores_Entrenadorid",
                table: "CanchaEspacios",
                column: "Entrenadorid",
                principalTable: "Entrenadores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
