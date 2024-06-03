using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_tarea")]
    public class TaakTipoTarea
    {        
        [Key]
        [Required]
        public int TipoTareaId { get; set; }

        [Required]
        public string? TipoTarea { get; set; }

        public List<TaakTarea>? LstTarea { get; set; }
    }
}
