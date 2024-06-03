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
    public class PlantillaRepository : IPlantillaRepository
    {
        private readonly ApplicationDbContext _context;

        public PlantillaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreatePlantilla(TaakPlantilla plantilla)
        {
            _context.TaakPlantilla.Add(plantilla);
            _context.SaveChanges();
        }

        public List<TaakPlantilla> GetAllPlantillas()
        {
            return _context.TaakPlantilla
                .Include(i => i.TipoPlantilla)
                .ToList();
        }

        public TaakPlantilla GetPlantilla(int plantillaId)
        {
            return _context.TaakPlantilla!
                .FirstOrDefault(f => f.PlantillaId == plantillaId)!;
        }

        public List<TaakPlantilla> GetPlantillaByClienteId(int clienteId)
        {
            return _context.TaakPlantilla
                .Include(i => i.TipoPlantilla)
                .Where(x => x.ClienteId == clienteId)
                .ToList();
        }

        public bool UpdatePlantilla(TaakPlantilla plantilla)
        {
            try
            {
                _context.TaakPlantilla.Update(plantilla);

                //var commmits = _context.SaveChanges();

                //if (commmits > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}

                return _context.SaveChanges() > 0? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
