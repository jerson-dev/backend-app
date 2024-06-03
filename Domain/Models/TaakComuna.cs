using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_comuna")]
    public class TaakComuna
    {
        [Key]
        [Required]        
        public int ComunaId { get; set; }

        [Required]
        public string Comuna { get; set; }

        [Required]
        [ForeignKey("RegionId")]
        public int RegionId { get; set; }
        
        public TaakRegion Region { get; set; }
    }
}
