using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_alumno")]
    public class TaakAlumno
    {
        [Key]
        [Required]
        public int AlumnoId { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        public string Rut { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Comuna { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Numero { get; set; }

        public string? NumeroDpto { get; set; }

        [Required]
        public string Longitud { get; set; }

        [Required]
        public string Latitud { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string AnioCurso { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [ForeignKey("CasaEstudioId")]
        public int CasaEstudioId { get; set; }    
        
        public TaakCasaEstudio CasaEstudio { get; set; }

        [Required]
        [ForeignKey("CarreraId")]
        public int CarreraId { get; set; }    
        
        public TaakCarrera Carrera { get; set; }

        [ForeignKey("DatoBancarioId")]
        public int? DatoBancarioId { get; set; }   
        
        public TaakDatosBancario DatoBancario { get; set; }

        [Required]
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }   
        
        public TaakUsuario Usuario { get; set; }

        [Required]
        [ForeignKey("ProspectoId")]
        public int ProspectoId { get; set; }
        public TaakProspecto Prospecto { get; set; }

        public List<TaakPostulacion>? lstPostulacion { get; set; }
    }
}
