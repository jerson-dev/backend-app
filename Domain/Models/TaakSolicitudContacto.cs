using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("taak_solicitud_contacto")]
    public class TaakSolicitudContacto
    {
        [Key]
        [Required]
        public int ContactoId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Consulta { get; set; }

        [Required]
        [ForeignKey("MotivoId")]
        public int MotivoId { get; set; }
        public TaakSolicitudMotivo Motivo { get; set; }
    }
}
