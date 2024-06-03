using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaakAlumno03052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "taak_alumno",
                newName: "SegundoNombre");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Comuna",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "taak_alumno",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "Comuna",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "taak_alumno");

            migrationBuilder.RenameColumn(
                name: "SegundoNombre",
                table: "taak_alumno",
                newName: "Nombre");
        }
    }
}
