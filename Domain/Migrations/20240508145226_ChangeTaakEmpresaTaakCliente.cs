using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTaakEmpresaTaakCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "taak_empresa",
                newName: "RazonSocial");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "taak_empresa",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "taak_empresa");

            migrationBuilder.RenameColumn(
                name: "RazonSocial",
                table: "taak_empresa",
                newName: "Nombre");
        }
    }
}
