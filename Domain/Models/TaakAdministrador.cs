using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_administrador")]
    public class TaakAdministrador
    {
        [Key]
        [Required]
        public int AdministradorId { get; set; }

        [Required]
        public string PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        public string Rut { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public bool IsContacto { get; set; } = false;
        
        [Required]
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }   
        
        public TaakUsuario Usuario { get; set; }

        public List<TaakKam>? lstKam { get; set; }
    }
}
