using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class TokenCorreoRepository : ITokenCorreoRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenCorreoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateTokenCorreo(TaakTokenCorreo tokenCorreo)
        {
            _context.TaakTokenCorreo.Add(tokenCorreo);
            _context.SaveChanges();
        }

        public TaakTokenCorreo GetByEmail(string email)
        {
            return _context.TaakTokenCorreo.FirstOrDefault(x => x.Email == email && x.Estado);
        }

        public void UpdateToken(TaakTokenCorreo tokenCorreo)
        {
            _context.TaakTokenCorreo.Update(tokenCorreo);
            _context.SaveChanges();
        }

        public List<TaakTokenCorreo> GetAll()
        {
            return _context.TaakTokenCorreo.ToList();
        }
    }
}
