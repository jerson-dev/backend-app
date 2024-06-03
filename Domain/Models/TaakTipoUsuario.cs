using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_tipo_usuario")]
    public class TaakTipoUsuario
    {
        [Key]
        [Required]
        public int TipoUsuarioId { get; set; }

        [Required]
        public string? TipoUsuario { get; set; }
    }
}
