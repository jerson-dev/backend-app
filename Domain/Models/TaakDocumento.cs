using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("taak_documento")]
    public class TaakDocumento
    {
        [Key]
        [Required]
        public int DocumentoId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Column(TypeName = "timestamp")] 
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string FilePath { get; set; }

        [Required]
        public string FileExtension { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        [ForeignKey("TipoDocumentoId")]
        public int? TipoDocumentoId { get; set; }

        public TaakTipoDocumento? TipoDocumento { get; set; }

        [Required]
        [ForeignKey("UsuarioId")]
        public int? UsuarioId { get; set; }
        public TaakUsuario? Usuario { get; set; }

    }
}
