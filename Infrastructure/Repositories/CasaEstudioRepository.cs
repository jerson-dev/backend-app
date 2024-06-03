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
    public class CasaEstudioRepository : ICasaEstudioRepository
    {
        private readonly ApplicationDbContext _context;

        public CasaEstudioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaakCasaEstudio> GetAll()
        {
            return _context.TaakCasaEstudio
                    .ToList();
        }
    }
}
