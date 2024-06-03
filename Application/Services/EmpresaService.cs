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
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public List<TaakEmpresa> GetEmpresas()
        {
            var listaEmpresas = _empresaRepository.GetAll();

            var empresasActivas = listaEmpresas.Where(e => e.Estado == true).ToList();

            return empresasActivas;
        }
    }
}
