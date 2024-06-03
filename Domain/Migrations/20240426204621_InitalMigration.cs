using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "taak_banco",
                columns: table => new
                {
                    BancoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Banco = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_banco", x => x.BancoId);
                });

            migrationBuilder.CreateTable(
                name: "taak_carrera",
                columns: table => new
                {
                    CarreraId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Carrera = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_carrera", x => x.CarreraId);
                });

            migrationBuilder.CreateTable(
                name: "taak_casa_estudio",
                columns: table => new
                {
                    CasaEstudioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CasaEstudio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_casa_estudio", x => x.CasaEstudioId);
                });

            migrationBuilder.CreateTable(
                name: "taak_region",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Region = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_region", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "taak_tipo_cuenta",
                columns: table => new
                {
                    TipoCuentaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoCuenta = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_cuenta", x => x.TipoCuentaId);
                });

            migrationBuilder.CreateTable(
                name: "taak_tipo_usuario",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoUsuario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_tipo_usuario", x => x.TipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "taak_comuna",
                columns: table => new
                {
                    ComunaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comuna = table.Column<string>(type: "text", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_comuna", x => x.ComunaId);
                    table.ForeignKey(
                        name: "FK_taak_comuna_taak_region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "taak_region",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taak_datos_bancarios",
                columns: table => new
                {
                    DatoBancarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NroCuenta = table.Column<int>(type: "integer", nullable: false),
                    BancoId = table.Column<int>(type: "integer", nullable: false),
                    TipoCuentaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_datos_bancarios", x => x.DatoBancarioId);
                    table.ForeignKey(
                        name: "FK_taak_datos_bancarios_taak_banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "taak_banco",
                        principalColumn: "BancoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_datos_bancarios_taak_tipo_cuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "taak_tipo_cuenta",
                        principalColumn: "TipoCuentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taak_usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usuario = table.Column<string>(type: "text", nullable: false),
                    Contrasena = table.Column<string>(type: "text", nullable: false),
                    TipoUsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_taak_usuario_taak_tipo_usuario_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "taak_tipo_usuario",
                        principalColumn: "TipoUsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taak_alumno",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "text", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "text", nullable: false),
                    Rut = table.Column<string>(type: "text", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    AnoCurso = table.Column<string>(type: "text", nullable: false),
                    ComunaId = table.Column<int>(type: "integer", nullable: false),
                    CasaEstudioId = table.Column<int>(type: "integer", nullable: false),
                    CarreraId = table.Column<int>(type: "integer", nullable: false),
                    DatoBancarioId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_alumno", x => x.AlumnoId);
                    table.ForeignKey(
                        name: "FK_taak_alumno_taak_carrera_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "taak_carrera",
                        principalColumn: "CarreraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_alumno_taak_casa_estudio_CasaEstudioId",
                        column: x => x.CasaEstudioId,
                        principalTable: "taak_casa_estudio",
                        principalColumn: "CasaEstudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_alumno_taak_comuna_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "taak_comuna",
                        principalColumn: "ComunaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_alumno_taak_datos_bancarios_DatoBancarioId",
                        column: x => x.DatoBancarioId,
                        principalTable: "taak_datos_bancarios",
                        principalColumn: "DatoBancarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_taak_alumno_taak_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taak_log",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descipcion = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taak_log", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_taak_log_taak_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "taak_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_taak_alumno_CarreraId",
                table: "taak_alumno",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_alumno_CasaEstudioId",
                table: "taak_alumno",
                column: "CasaEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_alumno_ComunaId",
                table: "taak_alumno",
                column: "ComunaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_alumno_DatoBancarioId",
                table: "taak_alumno",
                column: "DatoBancarioId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_alumno_UsuarioId",
                table: "taak_alumno",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_taak_comuna_RegionId",
                table: "taak_comuna",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_datos_bancarios_BancoId",
                table: "taak_datos_bancarios",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_datos_bancarios_TipoCuentaId",
                table: "taak_datos_bancarios",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_log_UsuarioId",
                table: "taak_log",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_taak_usuario_TipoUsuarioId",
                table: "taak_usuario",
                column: "TipoUsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taak_alumno");

            migrationBuilder.DropTable(
                name: "taak_log");

            migrationBuilder.DropTable(
                name: "taak_carrera");

            migrationBuilder.DropTable(
                name: "taak_casa_estudio");

            migrationBuilder.DropTable(
                name: "taak_comuna");

            migrationBuilder.DropTable(
                name: "taak_datos_bancarios");

            migrationBuilder.DropTable(
                name: "taak_usuario");

            migrationBuilder.DropTable(
                name: "taak_region");

            migrationBuilder.DropTable(
                name: "taak_banco");

            migrationBuilder.DropTable(
                name: "taak_tipo_cuenta");

            migrationBuilder.DropTable(
                name: "taak_tipo_usuario");
        }
    }
}
