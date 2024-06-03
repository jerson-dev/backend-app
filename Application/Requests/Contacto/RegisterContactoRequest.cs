using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Contacto
{
    public class RegisterContactoRequest
    {
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Consulta { get; set; }
        public int MotivoId { get; set; }

    }
}
