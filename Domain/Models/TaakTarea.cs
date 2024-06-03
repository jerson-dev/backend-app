using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tarea")]
    public class TaakTarea
    {
        [Key]
        [Required]
        public int TareaId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime FechaGestion { get; set; }

        [ForeignKey("UsuarioIngresoId")]
        public int? UsuarioIngresoId { get; set; }

        public TaakUsuario? UsuarioIngreso { get; set; }

        [ForeignKey("UsuarioGestionId")]
        public int? UsuarioGestionId { get; set; }

        public TaakUsuario? UsuarioGestion { get; set; }

        [ForeignKey("TipoTareaId")]
        public int? TipoTareaId { get; set; }

        public TaakTipoTarea? TipoTarea { get; set; }

        [ForeignKey("EstadoTareaId")]
        public int? EstadoTareaId { get; set; }

        public TaakEstadoTarea? EstadoTarea { get; set; }

        public List<TaakEnrolamiento>? LstEnrolamiento { get; set; }
    }
}
