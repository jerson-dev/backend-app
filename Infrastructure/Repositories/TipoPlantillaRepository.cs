using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TipoPlantillaRepository : ITipoPlantillaRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoPlantillaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TaakTipoPlantilla? GetTipoPlantillaId(int idTipoPlantilla)
        {
            return _context.TaakTipoPlantilla
                .Where(x => x.TipoPlantillaId == idTipoPlantilla)
                .FirstOrDefault();
        }

        public List<TaakTipoPlantilla> GetAllTipoPlantilla()
        {
            return _context.TaakTipoPlantilla
                    .ToList();
        }
    }
}
