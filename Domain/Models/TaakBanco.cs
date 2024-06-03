using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_banco")]
    public class TaakBanco
    {
        [Key]
        [Required]
        public int BancoId { get; set; }
        [Required]
        public string Banco { get; set; }
    }
}
