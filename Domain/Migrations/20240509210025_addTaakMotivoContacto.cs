using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class addTaakMotivoContacto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsContacto",
                table: "taak_administrador",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "taak_solicitud_motivo",
                columns: table => new
                {
                    MotivoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_solicitud_motivo", x => x.MotivoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_token_correo",
                columns: table => new
                {
                    TokenCorreoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_token_correo", x => x.TokenCorreoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_solicitud_contacto",
                columns: table => new
                {
                    ContactoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    Consulta = table.Column<string>(type: "text", nullable: false),
                    MotivoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_solicitud_contacto", x => x.ContactoId);
                    table.ForeignKey(
                        name: "FK_taak_solicitud_contacto_taak_solicitud_motivo_MotivoId",
                        column: x => x.MotivoId,
                        principalTable: "taak_solicitud_motivo",
                        principalColumn: "MotivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_solicitud_contacto_MotivoId",
                table: "taak_solicitud_contacto",
                column: "MotivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_solicitud_contacto");

            migrationBuilder.DropTable(
                name: "taak_token_correo");

            migrationBuilder.DropTable(
                name: "taak_solicitud_motivo");

            migrationBuilder.DropColumn(
                name: "IsContacto",
                table: "taak_administrador");
        }
    }
}
