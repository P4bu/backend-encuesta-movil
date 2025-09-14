using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class Updateencuesta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "Encuestas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_idUsuario",
                table: "Encuestas",
                column: "idUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Encuestas_idUsuario",
                table: "Encuestas");

            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "Encuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
