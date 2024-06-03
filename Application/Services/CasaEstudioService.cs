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
    public class CasaEstudioService : ICasaEstudioService
    {
        private readonly ICasaEstudioRepository _casaEstudioRepository;

        public CasaEstudioService(ICasaEstudioRepository casaEstudioRepository)
        {
            _casaEstudioRepository = casaEstudioRepository;
        }
        public List<TaakCasaEstudio> GetCasaEstudio()
        {
            var listaDominios = _casaEstudioRepository.GetAll();
            return listaDominios;
        }
    }
}
