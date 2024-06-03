using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationTaakUsuarioTaakAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_taak_administrador_UsuarioId",
                table: "taak_administrador");

            migrationBuilder.CreateIndex(
                name: "IX_taak_administrador_UsuarioId",
                table: "taak_administrador",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_taak_administrador_UsuarioId",
                table: "taak_administrador");

            migrationBuilder.CreateIndex(
                name: "IX_taak_administrador_UsuarioId",
                table: "taak_administrador",
                column: "UsuarioId");
        }
    }
}
