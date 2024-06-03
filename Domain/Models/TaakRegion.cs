using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_region")]
    public class TaakRegion
    {
        [Key]
        [Required]
        public int RegionId { get; set; }
        [Required]
        public string Region { get; set; }
    }
}
