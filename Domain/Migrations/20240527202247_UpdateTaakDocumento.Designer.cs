﻿// <auto-generated />
using System;
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
    [Migration("20240527202247_UpdateTaakDocumento")]
    partial class UpdateTaakDocumento
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.TaakAdministrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AdministradorId"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsContacto")
                        .HasColumnType("boolean");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("AdministradorId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("taak_administrador");
                });

            modelBuilder.Entity("Domain.Models.TaakAlumno", b =>
                {
                    b.Property<int>("AlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AlumnoId"));

                    b.Property<string>("AnioCurso")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CarreraId")
                        .HasColumnType("integer");

                    b.Property<int>("CasaEstudioId")
                        .HasColumnType("integer");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comuna")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("DatoBancarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("Date");

                    b.Property<string>("Latitud")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitud")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroDpto")
                        .HasColumnType("text");

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProspectoId")
                        .HasColumnType("integer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("AlumnoId");

                    b.HasIndex("CarreraId");

                    b.HasIndex("CasaEstudioId");

                    b.HasIndex("DatoBancarioId");

                    b.HasIndex("ProspectoId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("taak_alumno");
                });

            modelBuilder.Entity("Domain.Models.TaakAnuncio", b =>
                {
                    b.Property<int>("AnuncioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnuncioId"));

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comuna")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiaServicio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("JornadaInicio")
                        .IsRequired()
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("JornadaTermino")
                        .IsRequired()
                        .HasColumnType("timestamp");

                    b.Property<string>("Latitud")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitud")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("MontoPagar")
                        .IsRequired()
                        .HasColumnType("decimal(20, 10)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumeroDpto")
                        .HasColumnType("text");

                    b.Property<int>("PlantillaId")
                        .HasColumnType("integer");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AnuncioId");

                    b.HasIndex("PlantillaId")
                        .IsUnique();

                    b.ToTable("taak_anuncio");
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

            modelBuilder.Entity("Domain.Models.TaakCliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("Descipcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("taak_cliente");
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

            modelBuilder.Entity("Domain.Models.TaakDocumento", b =>
                {
                    b.Property<int>("DocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DocumentoId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TipoDocumentoId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("DocumentoId");

                    b.HasIndex("TipoDocumentoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("taak_documento");
                });

            modelBuilder.Entity("Domain.Models.TaakDominio", b =>
                {
                    b.Property<int>("DominioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DominioId"));

                    b.Property<int>("CasaEstudioId")
                        .HasColumnType("integer");

                    b.Property<string>("Dominio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DominioId");

                    b.HasIndex("CasaEstudioId");

                    b.ToTable("taak_dominio");
                });

            modelBuilder.Entity("Domain.Models.TaakEmpresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmpresaId"));

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("EmpresaId");

                    b.ToTable("taak_empresa");
                });

            modelBuilder.Entity("Domain.Models.TaakKam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministradorId")
                        .HasColumnType("integer");

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("ClienteId");

                    b.ToTable("taak_kam");
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

            modelBuilder.Entity("Domain.Models.TaakPlantilla", b =>
                {
                    b.Property<int>("PlantillaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlantillaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<string>("Descipcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("KamId")
                        .HasColumnType("integer");

                    b.Property<string>("Requisitos")
                        .HasColumnType("text");

                    b.Property<int>("TipoPlantillaId")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PlantillaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("KamId");

                    b.HasIndex("TipoPlantillaId");

                    b.ToTable("taak_plantilla");
                });

            modelBuilder.Entity("Domain.Models.TaakProspecto", b =>
                {
                    b.Property<int>("ProspectoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProspectoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProspectoId");

                    b.ToTable("taak_prospecto");
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

            modelBuilder.Entity("Domain.Models.TaakSolicitudContacto", b =>
                {
                    b.Property<int>("ContactoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ContactoId"));

                    b.Property<string>("Consulta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MotivoId")
                        .HasColumnType("integer");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ContactoId");

                    b.HasIndex("MotivoId");

                    b.ToTable("taak_solicitud_contacto");
                });

            modelBuilder.Entity("Domain.Models.TaakSolicitudMotivo", b =>
                {
                    b.Property<int>("MotivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MotivoId"));

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MotivoId");

                    b.ToTable("taak_solicitud_motivo");
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

            modelBuilder.Entity("Domain.Models.TaakTipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoDocumentoId"));

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("taak_tipo_documento");
                });

            modelBuilder.Entity("Domain.Models.TaakTipoPlantilla", b =>
                {
                    b.Property<int>("TipoPlantillaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipoPlantillaId"));

                    b.Property<string>("TipoPlantilla")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TipoPlantillaId");

                    b.ToTable("taak_tipo_plantilla");
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

            modelBuilder.Entity("Domain.Models.TaakTokenCorreo", b =>
                {
                    b.Property<int>("TokenCorreoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TokenCorreoId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Estado")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TokenCorreoId");

                    b.ToTable("taak_token_correo");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TaakEmpresaEmpresaId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoUsuarioId")
                        .HasColumnType("integer");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.HasIndex("TaakEmpresaEmpresaId");

                    b.HasIndex("TipoUsuarioId");

                    b.ToTable("taak_usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakAdministrador", b =>
                {
                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithOne("TaakAdministrador")
                        .HasForeignKey("Domain.Models.TaakAdministrador", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
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

                    b.HasOne("Domain.Models.TaakDatosBancario", "DatoBancario")
                        .WithMany()
                        .HasForeignKey("DatoBancarioId");

                    b.HasOne("Domain.Models.TaakProspecto", "Prospecto")
                        .WithMany()
                        .HasForeignKey("ProspectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithOne("TaakAlumno")
                        .HasForeignKey("Domain.Models.TaakAlumno", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");

                    b.Navigation("CasaEstudio");

                    b.Navigation("DatoBancario");

                    b.Navigation("Prospecto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakAnuncio", b =>
                {
                    b.HasOne("Domain.Models.TaakPlantilla", "Plantilla")
                        .WithOne("LstAnuncio")
                        .HasForeignKey("Domain.Models.TaakAnuncio", "PlantillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plantilla");
                });

            modelBuilder.Entity("Domain.Models.TaakCliente", b =>
                {
                    b.HasOne("Domain.Models.TaakEmpresa", "Empresa")
                        .WithMany("lstCliente")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

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

            modelBuilder.Entity("Domain.Models.TaakDocumento", b =>
                {
                    b.HasOne("Domain.Models.TaakTipoDocumento", "TipoDocumento")
                        .WithMany("LstDocumento")
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakUsuario", "Usuario")
                        .WithMany("LstDocumento")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDocumento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Models.TaakDominio", b =>
                {
                    b.HasOne("Domain.Models.TaakCasaEstudio", "CasaEstudio")
                        .WithMany()
                        .HasForeignKey("CasaEstudioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CasaEstudio");
                });

            modelBuilder.Entity("Domain.Models.TaakKam", b =>
                {
                    b.HasOne("Domain.Models.TaakAdministrador", "Administrador")
                        .WithMany("lstKam")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakCliente", "Cliente")
                        .WithMany("lstKam")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Cliente");
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

            modelBuilder.Entity("Domain.Models.TaakPlantilla", b =>
                {
                    b.HasOne("Domain.Models.TaakCliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakKam", "Kam")
                        .WithMany("LstPlantillas")
                        .HasForeignKey("KamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Models.TaakTipoPlantilla", "TipoPlantilla")
                        .WithMany("LstPlantilla")
                        .HasForeignKey("TipoPlantillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Kam");

                    b.Navigation("TipoPlantilla");
                });

            modelBuilder.Entity("Domain.Models.TaakSolicitudContacto", b =>
                {
                    b.HasOne("Domain.Models.TaakSolicitudMotivo", "Motivo")
                        .WithMany()
                        .HasForeignKey("MotivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motivo");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.HasOne("Domain.Models.TaakEmpresa", "TaakEmpresa")
                        .WithMany()
                        .HasForeignKey("TaakEmpresaEmpresaId");

                    b.HasOne("Domain.Models.TaakTipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("TipoUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaakEmpresa");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Domain.Models.TaakAdministrador", b =>
                {
                    b.Navigation("lstKam");
                });

            modelBuilder.Entity("Domain.Models.TaakCliente", b =>
                {
                    b.Navigation("lstKam");
                });

            modelBuilder.Entity("Domain.Models.TaakEmpresa", b =>
                {
                    b.Navigation("lstCliente");
                });

            modelBuilder.Entity("Domain.Models.TaakKam", b =>
                {
                    b.Navigation("LstPlantillas");
                });

            modelBuilder.Entity("Domain.Models.TaakPlantilla", b =>
                {
                    b.Navigation("LstAnuncio");
                });

            modelBuilder.Entity("Domain.Models.TaakTipoDocumento", b =>
                {
                    b.Navigation("LstDocumento");
                });

            modelBuilder.Entity("Domain.Models.TaakTipoPlantilla", b =>
                {
                    b.Navigation("LstPlantilla");
                });

            modelBuilder.Entity("Domain.Models.TaakUsuario", b =>
                {
                    b.Navigation("LstDocumento");

                    b.Navigation("TaakAdministrador");

                    b.Navigation("TaakAlumno");
                });
#pragma warning restore 612, 618
        }
    }
}