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
    public class ProspectoService : IProspectoService
    {
        private readonly IProspectoRepository _prospectoRepository;

        public ProspectoService(IProspectoRepository prospectoRepository)
        {
            _prospectoRepository = prospectoRepository;
        }
        public List<TaakProspecto> GetProspecto()
        {
            var listaProspectos = _prospectoRepository.GetAll();
            return listaProspectos;
        }
    }
}
