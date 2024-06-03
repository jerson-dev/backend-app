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
    public class CarreraRepository : ICarreraRepository
    {
        private readonly ApplicationDbContext _context;

        public CarreraRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaakCarrera> GetAll()
        {
            return _context.TaakCarrera
                    .ToList();
        }
    }
}
