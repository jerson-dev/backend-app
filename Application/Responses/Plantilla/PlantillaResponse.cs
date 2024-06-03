using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Plantilla
{
    public class PlantillaResponse
    {
        public string? Titulo { get; set; }

        public string? Descipcion { get; set; }

        public string? Requisitos { get; set; }

        public int ClienteId { get; set; }

        public int TipoPlantillaId { get; set; }

        public string? TipoPlantilla { get; set; }

        public int KamId { get; set; }

        public int PlantillaId { get; set; }
    }
}
