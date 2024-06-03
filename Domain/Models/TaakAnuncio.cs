using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("taak_anuncio")]
    public class TaakAnuncio
    {
        [Key]
        [Required]
        public int AnuncioId { get; set; }

        [Required]
        public string? DiaServicio { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime? JornadaInicio { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime? JornadaTermino { get; set; }

        [Required]
        [Column(TypeName = "decimal(20, 10)")]
        public decimal? MontoPagar { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? Region { get; set; }

        [Required]
        public string? Ciudad { get; set; }

        [Required]
        public string? Comuna { get; set; }

        [Required]
        public string? Direccion { get; set; }

        [Required]
        public string? Numero { get; set; }

        public string? NumeroDpto { get; set; }

        [Required]
        public string? Longitud { get; set; }

        [Required]
        public string? Latitud { get; set; }

        [Required]
        [ForeignKey("PlantillaId")]
        public int PlantillaId { get; set; }

        public TaakPlantilla? Plantilla { get; set; }

        public List<TaakPostulacion>? lstPostulacion { get; set; }
    }
}
