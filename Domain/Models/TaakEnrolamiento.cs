using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_enrolamiento")]
    public class TaakEnrolamiento
    {        
        [Key]
        [Required]
        public int EnrolamientoId { get; set; }

        [ForeignKey("TareaId")]
        public int? TareaId { get; set; }

        public TaakTarea? Tarea { get; set; }

        [ForeignKey("TipoEnrolamientoId")]
        public int? TipoEnrolamientoId { get; set; }

        public TaakTipoEnrolamiento? TipoEnrolamiento { get; set; }
    }
}
