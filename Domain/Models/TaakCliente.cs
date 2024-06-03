using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_cliente")]
    public class TaakCliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descipcion { get; set; }

        [Required]
        public string Rut { get; set; }

        [Required]
        public string Email { get; set; }


        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        [Required]
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public TaakUsuario Usuario { get; set; }

        [Required]
        [ForeignKey("EmpresaId")]
        public int EmpresaId { get; set; }

        public TaakEmpresa Empresa { get; set; }

        public List<TaakKam>? lstKam { get; set; }
    }
}
