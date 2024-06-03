using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Plantilla
{
    public class RegisterPlantillaRequest
    {

        public string? Titulo { get; set; }

        public string? Descipcion { get; set; }

        public string? Requisitos { get; set; }

        public int TipoPlantillaId { get; set; }

        public int KamId { get; set; }

    }
}
