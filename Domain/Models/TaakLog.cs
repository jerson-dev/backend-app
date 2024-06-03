using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_log")]
    public class TaakLog
    {
        [Key]
        [Required]
        public int LogId { get; set; }
        public string Descipcion { get; set; }

        [Required]
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public TaakUsuario Usuario { get; set; }
    }
}
