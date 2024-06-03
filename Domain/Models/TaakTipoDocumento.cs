using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_documento")]
    public class TaakTipoDocumento
    {
        [Key]
        [Required]
        public int TipoDocumentoId { get; set; }

        [Required]
        public string? TipoDocumento { get; set; }
        
        [Required]
        public string? Prefix { get; set; }

        public List<TaakDocumento> LstDocumento { get; set; }
    }
}
