using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationupdateesCompartidov2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esCompartido",
                table: "Transportes");

            migrationBuilder.AddColumn<bool>(
                name: "esCompartido",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "esCompartido",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "esCompartido",
                table: "Transportes",
                type: "bit",
                nullable: true);
        }
    }
}
