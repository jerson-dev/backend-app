using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class LogException
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "timestamp")]
        [Required]
        public required DateTime Timestamp { get; set; }
        [Required]
        public required string Message { get; set; }
        [Required]
        public required string InnerException { get; set; }
        [Required]
        public required string StackTrace { get; set; }
    }
}
