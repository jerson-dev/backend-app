using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTaakPostulacion28052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_Postulacion_estado",
                columns: table => new
                {
                    PostulacionEstadoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_Postulacion_estado", x => x.PostulacionEstadoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_Postulacion",
                columns: table => new
                {
                    PostulacionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostulacionEstadoId = table.Column<int>(type: "integer", nullable: false),
                    FechaPostulacion = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_Postulacion", x => x.PostulacionId);
                    table.ForeignKey(
                        name: "FK_taak_Postulacion_taak_Postulacion_estado_PostulacionEstadoId",
                        column: x => x.PostulacionEstadoId,
                        principalTable: "taak_Postulacion_estado",
                        principalColumn: "PostulacionEstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_Postulacion_PostulacionEstadoId",
                table: "taak_Postulacion",
                column: "PostulacionEstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_Postulacion");

            migrationBuilder.DropTable(
                name: "taak_Postulacion_estado");
        }
    }
}
