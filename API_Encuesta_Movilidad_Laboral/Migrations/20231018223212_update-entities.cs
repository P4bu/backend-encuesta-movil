using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Encuesta_Movilidad_Laboral.Migrations
{
    /// <inheritdoc />
    public partial class updateentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rutUsuario",
                table: "Encuestas",
                newName: "idUsuario");

            migrationBuilder.AlterColumn<bool>(
                name: "esCompartido",
                table: "TiposTransportes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "minutos_recorrido",
                table: "Encuestas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "km_recorrido",
                table: "Encuestas",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "dias_trabajo",
                table: "Encuestas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Encuestas",
                newName: "rutUsuario");

            migrationBuilder.AlterColumn<bool>(
                name: "esCompartido",
                table: "TiposTransportes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "minutos_recorrido",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "km_recorrido",
                table: "Encuestas",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "dias_trabajo",
                table: "Encuestas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
