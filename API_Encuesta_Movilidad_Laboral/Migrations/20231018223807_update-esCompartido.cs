using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class updateesCompartido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esCompartido",
                table: "TiposTransportes");

            migrationBuilder.AddColumn<bool>(
                name: "esCompartido",
                table: "Transportes",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esCompartido",
                table: "Transportes");

            migrationBuilder.AddColumn<bool>(
                name: "esCompartido",
                table: "TiposTransportes",
                type: "bit",
                nullable: true);
        }
    }
}
