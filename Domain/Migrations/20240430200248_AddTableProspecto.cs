using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTableProspecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_alumno_taak_comuna_ComunaId",
                table: "taak_alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_taak_alumno_taak_datos_bancarios_DatoBancarioId",
                table: "taak_alumno");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "taak_alumno");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "taak_alumno",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "ComunaId",
                table: "taak_alumno",
                newName: "ProspectoId");

            migrationBuilder.RenameIndex(
                name: "IX_taak_alumno_ComunaId",
                table: "taak_alumno",
                newName: "IX_taak_alumno_ProspectoId");

            migrationBuilder.AlterColumn<int>(
                name: "DatoBancarioId",
                table: "taak_alumno",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDpto",
                table: "taak_alumno",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "taak_prospecto",
                columns: table => new
                {
                    ProspectoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_prospecto", x => x.ProspectoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_taak_alumno_taak_datos_bancarios_DatoBancarioId",
                table: "taak_alumno",
                column: "DatoBancarioId",
                principalTable: "taak_datos_bancarios",
                principalColumn: "DatoBancarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_alumno_taak_prospecto_ProspectoId",
                table: "taak_alumno",
                column: "ProspectoId",
                principalTable: "taak_prospecto",
                principalColumn: "ProspectoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_alumno_taak_datos_bancarios_DatoBancarioId",
                table: "taak_alumno");

            migrationBuilder.DropForeignKey(
                name: "FK_taak_alumno_taak_prospecto_ProspectoId",
                table: "taak_alumno");

            migrationBuilder.DropTable(
                name: "taak_prospecto");

            migrationBuilder.DropColumn(
                name: "NumeroDpto",
                table: "taak_alumno");

            migrationBuilder.RenameColumn(
                name: "ProspectoId",
                table: "taak_alumno",
                newName: "ComunaId");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "taak_alumno",
                newName: "Numero");

            migrationBuilder.RenameIndex(
                name: "IX_taak_alumno_ProspectoId",
                table: "taak_alumno",
                newName: "IX_taak_alumno_ComunaId");

            migrationBuilder.AlterColumn<int>(
                name: "DatoBancarioId",
                table: "taak_alumno",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "taak_alumno",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_alumno_taak_comuna_ComunaId",
                table: "taak_alumno",
                column: "ComunaId",
                principalTable: "taak_comuna",
                principalColumn: "ComunaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taak_alumno_taak_datos_bancarios_DatoBancarioId",
                table: "taak_alumno",
                column: "DatoBancarioId",
                principalTable: "taak_datos_bancarios",
                principalColumn: "DatoBancarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
