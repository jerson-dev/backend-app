using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTaakDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "taak_documento",
                newName: "FileType");

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "taak_documento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "taak_documento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "taak_documento",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "taak_documento");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "taak_documento");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "taak_documento");

            migrationBuilder.RenameColumn(
                name: "FileType",
                table: "taak_documento",
                newName: "Titulo");
        }
    }
}
