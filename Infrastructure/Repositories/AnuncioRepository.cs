using Domain.Models;
using Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly ApplicationDbContext _context;

        public AnuncioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaakAnuncio> GetAnuncio()
        {
            return _context.TaakAnuncio
                .Include(i => i.Plantilla)
                    .ThenInclude(i => i!.TipoPlantilla)
                .Include(i => i.Plantilla)
                    .ThenInclude(i => i!.Cliente)
                .ToList();
        }

        public void CreateAnuncio(TaakAnuncio anuncio)
        {
            _context.TaakAnuncio.Add(anuncio);
            _context.SaveChanges();
        }

        public List<TaakAnuncio> GetAnunciosByClienteId(int clienteId)
        {
            return _context.TaakAnuncio
                .Include(i => i.Plantilla)
                    .ThenInclude(i => i!.Cliente)
                .Include(i => i.Plantilla)
                    .ThenInclude(i => i!.TipoPlantilla)
                .Where(a => a.Plantilla!.ClienteId == clienteId)
                .ToList();
        }

        public List<TaakAnuncio> GetAnuncioByBusqueda(string texto)
        {
            texto = texto.ToLower();

            //"Test".Contains("test", System.StringComparison.CurrentCultureIgnoreCase);
            return _context.TaakAnuncio
                .Include(a => a.Plantilla)
                    .ThenInclude(p => p!.TipoPlantilla)
                .Include(a => a.Plantilla)
                    .ThenInclude(p => p!.Cliente)
                .Where(a => a.Descripcion!.ToLower().Contains(texto) ||
                            a.Plantilla!.Descipcion!.ToLower().Contains(texto) ||
                            a.Plantilla!.TipoPlantilla!.TipoPlantilla!.ToLower().Contains(texto))
                .ToList();
        }
    }
}
