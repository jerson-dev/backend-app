using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_token_correo")]
    public class TaakTokenCorreo
    {
        [Key]
        [Required]
        public int TokenCorreoId { get; set; }

        [Required]
        public string Email { get; set; }

        public string Token { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int ContadorDePeticiones { get; set; }
    }
}
