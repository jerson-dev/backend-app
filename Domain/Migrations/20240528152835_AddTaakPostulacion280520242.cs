using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTaakPostulacion280520242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlumnoId",
                table: "taak_Postulacion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnuncioId",
                table: "taak_Postulacion",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_taak_Postulacion_AlumnoId",
                table: "taak_Postulacion",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_Postulacion_AnuncioId",
                table: "taak_Postulacion",
                column: "AnuncioId");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_Postulacion_taak_alumno_AlumnoId",
                table: "taak_Postulacion",
                column: "AlumnoId",
                principalTable: "taak_alumno",
                principalColumn: "AlumnoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taak_Postulacion_taak_anuncio_AnuncioId",
                table: "taak_Postulacion",
                column: "AnuncioId",
                principalTable: "taak_anuncio",
                principalColumn: "AnuncioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_Postulacion_taak_alumno_AlumnoId",
                table: "taak_Postulacion");

            migrationBuilder.DropForeignKey(
                name: "FK_taak_Postulacion_taak_anuncio_AnuncioId",
                table: "taak_Postulacion");

            migrationBuilder.DropIndex(
                name: "IX_taak_Postulacion_AlumnoId",
                table: "taak_Postulacion");

            migrationBuilder.DropIndex(
                name: "IX_taak_Postulacion_AnuncioId",
                table: "taak_Postulacion");

            migrationBuilder.DropColumn(
                name: "AlumnoId",
                table: "taak_Postulacion");

            migrationBuilder.DropColumn(
                name: "AnuncioId",
                table: "taak_Postulacion");
        }
    }
}
