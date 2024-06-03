using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class DocumentoRepository : IDocumentoRepository
    {
        private readonly ApplicationDbContext _context;

        public DocumentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool createDocumento(TaakDocumento documento)
        {
            try
            {
                _context.TaakDocumento.Add(documento);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public TaakDocumento? getProfileImageById(int userId)
        {
            return _context.TaakDocumento.Where(x => x.UsuarioId == userId && x.TipoDocumentoId == 1)
                .FirstOrDefault();
        }
    }
}
