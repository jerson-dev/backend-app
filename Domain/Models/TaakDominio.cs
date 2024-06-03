using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_dominio")]
    public class TaakDominio
    {
        [Key]
        [Required]
        public int DominioId { get; set; }
        [Required]
        public string Dominio { get; set; }

        [Required]
        [ForeignKey("CasaEstudioId")]
        public int CasaEstudioId { get; set; }

        public TaakCasaEstudio CasaEstudio { get; set; }
    }
}
