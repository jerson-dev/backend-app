using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Admin
{
    public class RegisterAdminRequest
    {
        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        public required string PrimerNombre { get; set; }
        public required string SegundoNombre { get; set; }
        public required string ApellidoPaterno { get; set; }
        public required string ApellidoMaterno { get; set; }
        public required string Rut { get; set; }
        public required string Email { get; set; }
        public required string Telefono { get; set; }
    }
}
