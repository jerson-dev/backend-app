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
    public class MotivoService : IMotivoService
    {
        private readonly IMotivoRepository _motivoRepository;

        public MotivoService(IMotivoRepository motivoRepository)
        {
            _motivoRepository = motivoRepository;
        }
        public List<TaakSolicitudMotivo> GetAllMotivos()
        {
            var listaMotivos = _motivoRepository.GetMotivo();
            return listaMotivos;
        }
    }
}
