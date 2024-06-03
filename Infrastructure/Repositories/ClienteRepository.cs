using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaakCliente> GetAll()
        {
            return _context.TaakCliente
                .Include(i => i.Empresa)
                .Include(i => i.lstKam)!
                .ThenInclude(i => i.Administrador)
                .ToList();
        }

        public void UpdateCliente(TaakCliente cliente)
        {
            _context.TaakCliente.Update(cliente);
            _context.SaveChanges();
        }

        public TaakCliente? GetById(int id)
        {
            return _context.TaakCliente.Where(x => x.ClienteId == id).FirstOrDefault();
        }
    }
}
