using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class add_TaakPlantilla_22052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_plantilla_taak_kam_LstKamId",
                table: "taak_plantilla");

            migrationBuilder.DropIndex(
                name: "IX_taak_plantilla_LstKamId",
                table: "taak_plantilla");

            migrationBuilder.DropColumn(
                name: "LstKamId",
                table: "taak_plantilla");

            migrationBuilder.CreateIndex(
                name: "IX_taak_plantilla_KamId",
                table: "taak_plantilla",
                column: "KamId");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_plantilla_taak_kam_KamId",
                table: "taak_plantilla",
                column: "KamId",
                principalTable: "taak_kam",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taak_plantilla_taak_kam_KamId",
                table: "taak_plantilla");

            migrationBuilder.DropIndex(
                name: "IX_taak_plantilla_KamId",
                table: "taak_plantilla");

            migrationBuilder.AddColumn<int>(
                name: "LstKamId",
                table: "taak_plantilla",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_taak_plantilla_LstKamId",
                table: "taak_plantilla",
                column: "LstKamId");

            migrationBuilder.AddForeignKey(
                name: "FK_taak_plantilla_taak_kam_LstKamId",
                table: "taak_plantilla",
                column: "LstKamId",
                principalTable: "taak_kam",
                principalColumn: "Id");
        }
    }
}
