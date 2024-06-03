using Application.Interfaces;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TipoPlantillaService : ITipoPlantillaService
    {
        private readonly ITipoPlantillaRepository _tipoPlantillaRepository;

        public TipoPlantillaService(ITipoPlantillaRepository tipoPlantillaRepository)
        {
            _tipoPlantillaRepository = tipoPlantillaRepository;
        }

        public List<TaakTipoPlantilla> GetAllTipoPlantilla()
        {
            var listaTipoPlantilla = _tipoPlantillaRepository.GetAllTipoPlantilla();
            return listaTipoPlantilla;
        }
    }
}
