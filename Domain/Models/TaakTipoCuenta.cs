using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_cuenta")]
    public class TaakTipoCuenta
    {
        [Key]
        [Required]
        public int TipoCuentaId { get; set; }

        [Required]
        public string TipoCuenta { get; set; }
    }
}
