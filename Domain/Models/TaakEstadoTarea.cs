using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_estado_tarea")]
    public class TaakEstadoTarea
    {        
        [Key]
        [Required]
        public int EstadoTareaId { get; set; }

        [Required]
        public string? EstadoTarea { get; set; }

        public List<TaakTarea>? LstTarea { get; set; }
    }
}
