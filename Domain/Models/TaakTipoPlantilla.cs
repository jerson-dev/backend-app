using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_plantilla")]
    public class TaakTipoPlantilla
    {
        [Key]
        [Required]
        public int TipoPlantillaId { get; set; }

        [Required]
        public string? TipoPlantilla { get; set; }

        public List<TaakPlantilla>? LstPlantilla { get; set; }
    }
}
