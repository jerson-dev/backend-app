using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class add_TaakAnuncio_22052024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_tipo_plantilla",
                columns: table => new
                {
                    TipoPlantillaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoPlantilla = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_plantilla", x => x.TipoPlantillaId);
                });

            migrationBuilder.CreateTable(
                name: "taak_plantilla",
                columns: table => new
                {
                    PlantillaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descipcion = table.Column<string>(type: "text", nullable: false),
                    Requisitos = table.Column<string>(type: "text", nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    TipoPlantillaId = table.Column<int>(type: "integer", nullable: false),
                    KamId = table.Column<int>(type: "integer", nullable: false),
                    LstKamId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_plantilla", x => x.PlantillaId);
                    table.ForeignKey(
                        name: "FK_taak_plantilla_taak_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "taak_cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_plantilla_taak_kam_LstKamId",
                        column: x => x.LstKamId,
                        principalTable: "taak_kam",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_taak_plantilla_taak_tipo_plantilla_TipoPlantillaId",
                        column: x => x.TipoPlantillaId,
                        principalTable: "taak_tipo_plantilla",
                        principalColumn: "TipoPlantillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taak_anuncio",
                columns: table => new
                {
                    AnuncioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiaServicio = table.Column<string>(type: "text", nullable: false),
                    JornadaInicio = table.Column<string>(type: "text", nullable: false),
                    JornadaTermino = table.Column<string>(type: "text", nullable: false),
                    MontoPagar = table.Column<decimal>(type: "numeric(20,10)", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    Ciudad = table.Column<string>(type: "text", nullable: false),
                    Comuna = table.Column<string>(type: "text", nullable: false),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    NumeroDpto = table.Column<string>(type: "text", nullable: true),
                    Longitud = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<string>(type: "text", nullable: false),
                    PlantillaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_anuncio", x => x.AnuncioId);
                    table.ForeignKey(
                        name: "FK_taak_anuncio_taak_plantilla_PlantillaId",
                        column: x => x.PlantillaId,
                        principalTable: "taak_plantilla",
                        principalColumn: "PlantillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_anuncio_PlantillaId",
                table: "taak_anuncio",
                column: "PlantillaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_taak_plantilla_ClienteId",
                table: "taak_plantilla",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_plantilla_LstKamId",
                table: "taak_plantilla",
                column: "LstKamId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_plantilla_TipoPlantillaId",
                table: "taak_plantilla",
                column: "TipoPlantillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_anuncio");

            migrationBuilder.DropTable(
                name: "taak_plantilla");

            migrationBuilder.DropTable(
                name: "taak_tipo_plantilla");
        }
    }
}
