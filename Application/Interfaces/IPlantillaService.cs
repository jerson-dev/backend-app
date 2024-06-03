using Application.Requests.Plantilla;
using Application.Responses.Plantilla;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlantillaService
    {
        public void CreatePlantilla(RegisterPlantillaRequest plantilla);

        public List<TaakPlantilla> GetAllPlantillas();

        public List<PlantillaResponse> GetPlantillaByClienteId(int clienteId);

        public bool UpdatePlantilla(int id, UpdatePlantillaRequest plantillaRequest);
    }
}
