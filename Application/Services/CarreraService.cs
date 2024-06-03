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
    public class CarreraService : ICarreraService
    {
        private readonly ICarreraRepository _carreraRepository;

        public CarreraService(ICarreraRepository carreraRepository)
        {
            _carreraRepository = carreraRepository;
        }
        public List<TaakCarrera> GetCarrera()
        {
            var listaDominios = _carreraRepository.GetAll();
            return listaDominios;
        }
    }
}
