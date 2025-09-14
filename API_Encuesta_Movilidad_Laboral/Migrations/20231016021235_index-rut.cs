using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class indexrut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "rut",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_rut",
                table: "AspNetUsers",
                column: "rut");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_rut",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "rut",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
