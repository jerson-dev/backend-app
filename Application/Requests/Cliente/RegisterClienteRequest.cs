using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Cliente
{
    public class RegisterClienteRequest
    {
        public string? RazonSocial { get; set; }

        public string? Descipcion { get; set; }

        public string? Rut { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }
        
        public int? EmpresaId { get; set; }

        public int? AdministradorId { get; set; }

    }
}
