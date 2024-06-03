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
    public class DominioService : IDominioService
    {
        private readonly IDominioRepository _dominioRepository;

        public DominioService(IDominioRepository dominioRepository)
        {
            _dominioRepository = dominioRepository;
        }
        public List<TaakDominio> GetDominios()
        {
            var listaDominios = _dominioRepository.GetAllDominios();
            return listaDominios;
        }
    }
}
