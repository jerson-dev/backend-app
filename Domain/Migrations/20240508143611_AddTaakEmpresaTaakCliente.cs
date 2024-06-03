using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddTaakEmpresaTaakCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaakEmpresaEmpresaId",
                table: "taak_usuario",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "taak_empresa",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_empresa", x => x.EmpresaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_usuario_TaakEmpresaEmpresaId",
                table: "taak_usuario",
                column: "TaakEmpresaEmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_usuario_taak_empresa_TaakEmpresaEmpresaId",
                table: "taak_usuario",
                column: "TaakEmpresaEmpresaId",
                principalTable: "taak_empresa",
                principalColumn: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_usuario_taak_empresa_TaakEmpresaEmpresaId",
                table: "taak_usuario");

            migrationBuilder.DropTable(
                name: "taak_empresa");

            migrationBuilder.DropIndex(
                name: "IX_taak_usuario_TaakEmpresaEmpresaId",
                table: "taak_usuario");

            migrationBuilder.DropColumn(
                name: "TaakEmpresaEmpresaId",
                table: "taak_usuario");
        }
    }
}
