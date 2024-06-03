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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TaakUsuario> GetAll()
        {
            return _context.TaakUsuario
                .Include(x=>x.TipoUsuario)
                .ToList();
        }

        public TaakUsuario? GetUserById(int id)
        {
            return _context.TaakUsuario
                .Where(x => x.UsuarioId == id)
                .FirstOrDefault();
        }
    }
}
