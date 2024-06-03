using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_usuario")]
    public class TaakUsuario
    {        
        [Key]
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Contrasenia { get; set; }

        [Required]
        [ForeignKey("TipoUsuarioId")]
        public int TipoUsuarioId { get; set; }

        public TaakTipoUsuario TipoUsuario { get; set; }

        public TaakAlumno? TaakAlumno { get; set; } = null;

        public TaakAdministrador? TaakAdministrador { get; set; } = null;

        public TaakEmpresa? TaakEmpresa { get; set; } = null;

        public List<TaakDocumento>? LstDocumento { get; set; }
    }
}
