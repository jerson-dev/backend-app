using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Cliente
{
    public class UpdateClienteRequest
    {
        public int ClienteId { get; set; }

        public string? RazonSocial { get; set; }

        public string? Descipcion { get; set; }

        public string? Rut { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }
    }
}
