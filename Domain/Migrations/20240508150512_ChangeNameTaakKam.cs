using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTaakKam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaakKam_taak_administrador_AdministradorId",
                table: "TaakKam");

            migrationBuilder.DropForeignKey(
                name: "FK_TaakKam_taak_cliente_ClienteId",
                table: "TaakKam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaakKam",
                table: "TaakKam");

            migrationBuilder.RenameTable(
                name: "TaakKam",
                newName: "taak_kam");

            migrationBuilder.RenameIndex(
                name: "IX_TaakKam_ClienteId",
                table: "taak_kam",
                newName: "IX_taak_kam_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_TaakKam_AdministradorId",
                table: "taak_kam",
                newName: "IX_taak_kam_AdministradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_taak_kam",
                table: "taak_kam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_kam_taak_administrador_AdministradorId",
                table: "taak_kam",
                column: "AdministradorId",
                principalTable: "taak_administrador",
                principalColumn: "AdministradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taak_kam_taak_cliente_ClienteId",
                table: "taak_kam",
                column: "ClienteId",
                principalTable: "taak_cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_kam_taak_administrador_AdministradorId",
                table: "taak_kam");

            migrationBuilder.DropForeignKey(
                name: "FK_taak_kam_taak_cliente_ClienteId",
                table: "taak_kam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_taak_kam",
                table: "taak_kam");

            migrationBuilder.RenameTable(
                name: "taak_kam",
                newName: "TaakKam");

            migrationBuilder.RenameIndex(
                name: "IX_taak_kam_ClienteId",
                table: "TaakKam",
                newName: "IX_TaakKam_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_taak_kam_AdministradorId",
                table: "TaakKam",
                newName: "IX_TaakKam_AdministradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaakKam",
                table: "TaakKam",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaakKam_taak_administrador_AdministradorId",
                table: "TaakKam",
                column: "AdministradorId",
                principalTable: "taak_administrador",
                principalColumn: "AdministradorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaakKam_taak_cliente_ClienteId",
                table: "TaakKam",
                column: "ClienteId",
                principalTable: "taak_cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
