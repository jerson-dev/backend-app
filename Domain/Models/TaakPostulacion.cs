using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_Postulacion")]
    public class TaakPostulacion
    {
        [Key]
        [Required]
        public int PostulacionId { get; set; }

        [Required]
        [ForeignKey("PostulacionEstadoId")]
        public int PostulacionEstadoId { get; set; }

        public TaakPostulacionEstado? PostulacionEstado { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime? FechaPostulacion { get; set; }

        [Required]
        [ForeignKey("AnuncioId")]
        public int AnuncioId { get; set; }

        public TaakAnuncio? Anuncio { get; set; }

        [Required]
        [ForeignKey("AlumnoId")]
        public int AlumnoId { get; set; }

        public TaakAlumno? Alumno { get; set; }
    }
}
