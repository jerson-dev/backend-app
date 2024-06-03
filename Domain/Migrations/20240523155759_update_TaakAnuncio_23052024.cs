using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class update_TaakAnuncio_23052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JornadaInicio",
                table: "taak_anuncio");

            migrationBuilder.DropColumn(
                name: "JornadaTermino",
                table: "taak_anuncio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JornadaInicio",
                table: "taak_anuncio",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JornadaTermino",
                table: "taak_anuncio",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
