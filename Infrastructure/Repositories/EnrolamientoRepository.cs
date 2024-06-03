using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnrolamientoRepository : IEnrolamientoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrolamientoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
