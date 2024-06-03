using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_Postulacion_estado")]
    public class TaakPostulacionEstado
    {
        [Key]
        [Required]
        public int PostulacionEstadoId { get; set; }

        [Required]
        public string? Estado { get; set; }

        public List<TaakPostulacion>? lstPostulacion { get; set; }

    }
}
