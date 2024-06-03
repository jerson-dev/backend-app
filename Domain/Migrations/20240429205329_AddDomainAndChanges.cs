using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainAndChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasena",
                table: "taak_usuario",
                newName: "Contrasenia");

            migrationBuilder.RenameColumn(
                name: "AnoCurso",
                table: "taak_alumno",
                newName: "AnioCurso");

            migrationBuilder.CreateTable(
                name: "taak_dominio",
                columns: table => new
                {
                    DominioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dominio = table.Column<string>(type: "text", nullable: false),
                    CasaEstudioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_dominio", x => x.DominioId);
                    table.ForeignKey(
                        name: "FK_taak_dominio_taak_casa_estudio_CasaEstudioId",
                        column: x => x.CasaEstudioId,
                        principalTable: "taak_casa_estudio",
                        principalColumn: "CasaEstudioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_dominio_CasaEstudioId",
                table: "taak_dominio",
                column: "CasaEstudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_dominio");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "taak_usuario",
                newName: "Contrasena");

            migrationBuilder.RenameColumn(
                name: "AnioCurso",
                table: "taak_alumno",
                newName: "AnoCurso");
        }
    }
}
