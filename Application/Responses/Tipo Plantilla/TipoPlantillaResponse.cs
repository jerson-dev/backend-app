using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Tipo_Plantilla
{
    public class TipoPlantillaResponse
    {
        public int TipoPlantillaId { get; set; }

        public string? TipoPlantilla { get; set; }
    }
}
