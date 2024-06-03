using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Dominio
{
    public class EmpresaResponse
    {
        public int Id { get; set; }

        public string RazonSocial { get; set; }
    }
}
