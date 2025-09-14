using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class updatechanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "idUsuario",
                table: "Encuestas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "idUsuario",
                table: "Encuestas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
