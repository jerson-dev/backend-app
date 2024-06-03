using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPlantillaRepository
    {
        public void CreatePlantilla(TaakPlantilla plantilla);

        public List<TaakPlantilla> GetAllPlantillas();

        TaakPlantilla GetPlantilla(int plantillaId);

        public List<TaakPlantilla> GetPlantillaByClienteId(int clienteId);

        public bool UpdatePlantilla(TaakPlantilla plantilla);
    }
}
