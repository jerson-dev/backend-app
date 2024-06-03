using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Domain.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaakTipoUsuario> TaakTipoUsuario { get; set; }
        public DbSet<TaakUsuario> TaakUsuario { get; set; }
        public DbSet<TaakAlumno> TaakAlumno { get; set; }        
        public DbSet<TaakAdministrador> TaakAdministrador { get; set; }        
        public DbSet<TaakRegion> TaakRegion { get; set; }
        public DbSet<TaakComuna> TaakComuna { get; set; }
        public DbSet<TaakDatosBancario> TaakDatosBancarios { get; set; }
        public DbSet<TaakBanco> TaakBanco { get; set; }
        public DbSet<TaakTipoCuenta> TaakTipoCuenta { get; set; }
        public DbSet<TaakCasaEstudio> TaakCasaEstudio { get; set; }
        public DbSet<TaakCarrera> TaakCarrera { get; set; }
        public DbSet<TaakLog> TaakLog { get; set; }
        public DbSet<TaakDominio> TaakDominio { get; set; }
        public DbSet<TaakProspecto> TaakProspecto { get; set; }
        public DbSet<TaakCliente> TaakCliente { get; set; }
        public DbSet<TaakEmpresa> TaakEmpresa { get; set; }
        public DbSet<TaakKam> TaakKam { get; set; }
        public DbSet<TaakSolicitudContacto> TaakSolicitudContacto { get; set; }
        public DbSet<TaakSolicitudMotivo> TaakSolicitudMotivo { get; set; }
        public DbSet<TaakTokenCorreo> TaakTokenCorreo { get; set; }
        public DbSet<TaakTipoPlantilla> TaakTipoPlantilla { get; set; }
        public DbSet<TaakPlantilla> TaakPlantilla { get; set; }
        public DbSet<TaakAnuncio> TaakAnuncio { get; set; }    
        public DbSet<TaakDocumento> TaakDocumento { get; set; }    
        public DbSet<TaakTipoDocumento> TaakTipoDocumento { get; set; }
        public DbSet<TaakPostulacionEstado> TaakPostulacionEstado { get; set; }
        public DbSet<TaakPostulacion> TaakPostulacion { get; set; }
        public DbSet<TaakEnrolamiento> TaakEnrolamiento { get; set; }
        public DbSet<TaakTipoEnrolamiento> TaakTipoEnrolamiento { get; set; }
        public DbSet<TaakTipoTarea> TaakTipoTarea { get; set; }
        public DbSet<TaakEstadoTarea> TaakEstadoTarea { get; set; }
        public DbSet<TaakTarea> TaakTarea { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
