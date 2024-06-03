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
    public class DominioRepository : IDominioRepository
    {
        private readonly ApplicationDbContext _context;

        public DominioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaakDominio> GetAllDominios()
        {
            return _context.TaakDominio
                    .Include(x=>x.CasaEstudio)
                    .ToList();
        }

    }
}
