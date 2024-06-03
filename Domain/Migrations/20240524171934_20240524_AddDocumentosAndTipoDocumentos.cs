using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class _20240524_AddDocumentosAndTipoDocumentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_tipo_documento",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoDocumento = table.Column<string>(type: "text", nullable: false),
                    Prefix = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_documento", x => x.TipoDocumentoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_documento",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_documento", x => x.DocumentoId);
                    table.ForeignKey(
                        name: "FK_taak_documento_taak_tipo_documento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "taak_tipo_documento",
                        principalColumn: "TipoDocumentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_documento_taak_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_documento_TipoDocumentoId",
                table: "taak_documento",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_documento_UsuarioId",
                table: "taak_documento",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_documento");

            migrationBuilder.DropTable(
                name: "taak_tipo_documento");
        }
    }
}
