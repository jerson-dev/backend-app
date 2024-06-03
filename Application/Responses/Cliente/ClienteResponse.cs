using Application.Responses.Admin;

using Domain.Models;

namespace Application.Responses.Cliente
{
    public class ClienteResponse
    {
        public int ClienteId { get; set; }

        public string? RazonSocial { get; set; }

        public string? Descipcion { get; set; }

        public string? Rut { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public int? EmpresaId { get; set; }

        public string? Empresa { get; set; }

        public List<AdminResponse>? lstAdminResponse { get; set; }
    }
}
