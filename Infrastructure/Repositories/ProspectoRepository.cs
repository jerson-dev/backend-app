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
    public class ProspectoRepository : IProspectoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProspectoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaakProspecto> GetAll()
        {
            return _context.TaakProspecto
                    .ToList();
        }
    }
}
