using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_empresa")]
    public class TaakEmpresa
    {
        [Key]
        public int EmpresaId { get; set; }

        [Required]
        public string RazonSocial { get; set; }

        [Required]
        public bool Estado { get; set; }

        public List<TaakCliente>? lstCliente { get; set; }
    }
}
