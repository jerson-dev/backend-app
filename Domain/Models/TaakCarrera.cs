using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_carrera")]
    public class TaakCarrera
    {
        [Key]
        [Required]
        public int CarreraId { get; set; }
        [Required]
        public string Carrera { get; set; }        
    }
}
