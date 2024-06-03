using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("taak_plantilla")]
    public class TaakPlantilla
    {
        [Key]
        [Required]
        public int PlantillaId { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Descipcion { get; set; }

        public string? Requisitos { get; set; }

        [Required]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }

        public TaakCliente? Cliente { get; set; }

        [Required]
        [ForeignKey("TipoPlantillaId")]
        public int TipoPlantillaId { get; set; }

        public TaakTipoPlantilla? TipoPlantilla { get; set; }

        [Required]
        [ForeignKey("KamId")]
        public int KamId { get; set; }

        public TaakKam? Kam { get; set; }

        public TaakAnuncio? LstAnuncio { get; set; }
    }
}
