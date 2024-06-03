using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_datos_bancarios")]
    public class TaakDatosBancario
    {
        [Key]
        [Required]
        public int DatoBancarioId { get; set; }
        [Required]
        public int NroCuenta { get; set; }
        [Required]
        [ForeignKey("BancoId")]
        public int BancoId { get; set; }
        
        public TaakBanco Banco { get; set; }

        [Required]
        [ForeignKey("TipoCuentaId")]
        public int TipoCuentaId { get; set; }
        
        public TaakTipoCuenta TipoCuenta { get; set; }
    }
}
