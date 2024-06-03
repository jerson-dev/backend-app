using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTaakKam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descipcion = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    EmpresaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_taak_cliente_taak_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "taak_empresa",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_cliente_taak_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaakKam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdministradorId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaakKam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaakKam_taak_administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "taak_administrador",
                        principalColumn: "AdministradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaakKam_taak_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "taak_cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaakKam_AdministradorId",
                table: "TaakKam",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_TaakKam_ClienteId",
                table: "TaakKam",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_cliente_EmpresaId",
                table: "taak_cliente",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_cliente_UsuarioId",
                table: "taak_cliente",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaakKam");

            migrationBuilder.DropTable(
                name: "taak_cliente");
        }
    }
}
