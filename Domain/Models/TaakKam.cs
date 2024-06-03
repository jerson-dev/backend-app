using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_kam")]
    public class TaakKam
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        [ForeignKey("AdministradorId")]
        public int AdministradorId { get; set; }
        public TaakAdministrador Administrador { get; set; }

        [Required]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public TaakCliente Cliente { get; set; }

        public List<TaakPlantilla>? LstPlantillas { get; set; }
    }
}
