﻿// <auto-generated />
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240426204621_InitalMigration")]
    partial class InitalMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.TaakAlumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlumnoId"));

                    b.Property<string>("AnoCurso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CarreraId")
                        .HasColumnType("integer");

                    b.Property<int>("CasaEstudioId")
                        .HasColumnType("integer");

                    b.Property<int>("ComunaId")
                        .HasColumnType("integer");

                    b.Property<int>("DatoBancarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("AlumnoId");

                    b.HasIndex("CarreraId");

                    b.HasIndex("CasaEstudioId");

                    b.HasIndex("ComunaId");

                    b.HasIndex("DatoBancarioId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("taak_alumno");
                });

            modelBuilder.Entity("Domain.Models.TaakBanco", b =>
                {
                    b.Property<int>("BancoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BancoId"));

                    b.Property<string>("Banco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BancoId");

                    b.ToTable("taak_banco");
                });

            modelBuilder.Entity("Domain.Models.TaakCarrera", b =>
                {
                    b.Property<int>("CarreraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarreraId"));

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CarreraId");

                    b.ToTable("taak_carrera");
                });

            modelBuilder.Entity("Domain.Models.TaakCasaEstudio", b =>
                {
                    b.Property<int>("CasaEstudioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CasaEstudioId"));

                    b.Property<string>("CasaEstudio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CasaEstudioId");

                    b.ToTable("taak_casa_estudio");
                });

            modelBuilder.Entity("Domain.Models.TaakComuna", b =>
                {
                    b.Property<int>("ComunaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ComunaId"));

                    b.Property<string>("Comuna")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RegionId")
                        .HasColumnType("integer");

                    b.HasKey("ComunaId");

                    b.HasIndex("RegionId");

                    b.ToTable("taak_comuna");
                });

            modelBuilder.Entity("Domain.Models.TaakDatosBancario", b =>
                {
                    b.Property<int>("DatoBancarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DatoBancarioId"));

                    b.Property<int>("BancoId")
                        .HasColumnType("integer");

                    b.Property<int>("NroCuenta")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCuentaId")
                        .HasColumnType("integer");

                    b.HasKey("DatoBancarioId");

                    b.HasIndex("BancoId");

                    b.HasIndex("TipoCuentaId");

                    b.ToTable("taak_datos_bancarios");
                });

            modelBuilder.Entity("Domain.Models.TaakLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LogId"));

                    b.Property<string>("Descipcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("LogId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("taak_log");
                });

            modelBuilder.Entity("Domain.Models.TaakRegion", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RegionId"));

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RegionId");

                    b.ToTable("taak_region");
                });

            modelBuilder.Entity("Domain.Models.TaakTipoCuenta", b =>
                {
                    b.Property<int>("TipoCuentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoCuentaId"));

                    b.Property<string>("TipoCuenta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoCuentaId");

                    b.ToTable("taak_tipo_cuenta");
                });

            modelBuilder.Entity("Domain.Models.TaakTipoUsuario", b =>
                {
                    b.Property<int>("TipoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoUsuarioId"));

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoUsuarioId");

                    b.ToTable("taak_tipo_usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("taak_usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakAlumno", b =>
                {
                    b.HasOne("Domain.Models.TaakCarrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakCasaEstudio", "CasaEstudio")
                        .WithMany()
                        .HasForeignKey("CasaEstudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakComuna", "Comuna")
                        .WithMany()
                        .HasForeignKey("ComunaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakDatosBancario", "DatoBancario")
                        .WithMany()
                        .HasForeignKey("DatoBancarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithOne("TaakAlumno")
                        .HasForeignKey("Domain.Models.TaakAlumno", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("CasaEstudio");

                    b.Navigation("Comuna");

                    b.Navigation("DatoBancario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakComuna", b =>
                {
                    b.HasOne("Domain.Models.TaakRegion", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Domain.Models.TaakDatosBancario", b =>
                {
                    b.HasOne("Domain.Models.TaakBanco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakTipoCuenta", "TipoCuenta")
                        .WithMany()
                        .HasForeignKey("TipoCuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");

                    b.Navigation("TipoCuenta");
                });

            modelBuilder.Entity("Domain.Models.TaakLog", b =>
                {
                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.HasOne("Domain.Models.TaakTipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.Navigation("TaakAlumno")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
