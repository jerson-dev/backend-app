using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTaakTarea30052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_estado_tarea",
                columns: table => new
                {
                    EstadoTareaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstadoTarea = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_estado_tarea", x => x.EstadoTareaId);
                });

            migrationBuilder.CreateTable(
                name: "taak_tipo_enrolamiento",
                columns: table => new
                {
                    TipoEnrolamientoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoEnrolamiento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_enrolamiento", x => x.TipoEnrolamientoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_tipo_tarea",
                columns: table => new
                {
                    TipoTareaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoTarea = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_tarea", x => x.TipoTareaId);
                });

            migrationBuilder.CreateTable(
                name: "taak_tarea",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaGestion = table.Column<DateTime>(type: "Date", nullable: false),
                    UsuarioIngresoId = table.Column<int>(type: "integer", nullable: true),
                    UsuarioGestionId = table.Column<int>(type: "integer", nullable: true),
                    TipoTareaId = table.Column<int>(type: "integer", nullable: true),
                    EstadoTareaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_taak_tarea_taak_estado_tarea_EstadoTareaId",
                        column: x => x.EstadoTareaId,
                        principalTable: "taak_estado_tarea",
                        principalColumn: "EstadoTareaId");
                    table.ForeignKey(
                        name: "FK_taak_tarea_taak_tipo_tarea_TipoTareaId",
                        column: x => x.TipoTareaId,
                        principalTable: "taak_tipo_tarea",
                        principalColumn: "TipoTareaId");
                    table.ForeignKey(
                        name: "FK_taak_tarea_taak_usuario_UsuarioGestionId",
                        column: x => x.UsuarioGestionId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_taak_tarea_taak_usuario_UsuarioIngresoId",
                        column: x => x.UsuarioIngresoId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateTable(
                name: "taak_enrolamiento",
                columns: table => new
                {
                    EnrolamientoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TareaId = table.Column<int>(type: "integer", nullable: true),
                    TipoEnrolamientoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_enrolamiento", x => x.EnrolamientoId);
                    table.ForeignKey(
                        name: "FK_taak_enrolamiento_taak_tarea_TareaId",
                        column: x => x.TareaId,
                        principalTable: "taak_tarea",
                        principalColumn: "TareaId");
                    table.ForeignKey(
                        name: "FK_taak_enrolamiento_taak_tipo_enrolamiento_TipoEnrolamientoId",
                        column: x => x.TipoEnrolamientoId,
                        principalTable: "taak_tipo_enrolamiento",
                        principalColumn: "TipoEnrolamientoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_enrolamiento_TareaId",
                table: "taak_enrolamiento",
                column: "TareaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_enrolamiento_TipoEnrolamientoId",
                table: "taak_enrolamiento",
                column: "TipoEnrolamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_tarea_EstadoTareaId",
                table: "taak_tarea",
                column: "EstadoTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_tarea_TipoTareaId",
                table: "taak_tarea",
                column: "TipoTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_tarea_UsuarioGestionId",
                table: "taak_tarea",
                column: "UsuarioGestionId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_tarea_UsuarioIngresoId",
                table: "taak_tarea",
                column: "UsuarioIngresoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_enrolamiento");

            migrationBuilder.DropTable(
                name: "taak_tarea");

            migrationBuilder.DropTable(
                name: "taak_tipo_enrolamiento");

            migrationBuilder.DropTable(
                name: "taak_estado_tarea");

            migrationBuilder.DropTable(
                name: "taak_tipo_tarea");
        }
    }
}
