using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_enrolamiento")]
    public class TaakTipoEnrolamiento
    {        
        [Key]
        [Required]
        public int TipoEnrolamientoId { get; set; }

        [Required]
        public string? TipoEnrolamiento { get; set; }

        public List<TaakEnrolamiento>? LstEnrolamiento { get; set; }
    }
}
