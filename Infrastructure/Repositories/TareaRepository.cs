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
    public class TareaRepository : ITareaRepository
    {
        private readonly ApplicationDbContext _context;

        public TareaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaakTarea> GetTareaByTipoTareaId(int tipoTareaId)
        {
            return _context.TaakTarea
                .Include(i => i.EstadoTarea)
                .Include(i => i.UsuarioIngreso)
                    .ThenInclude(i => i!.TaakAlumno)
                .Include(i => i.TipoTarea)
                .Where(x => x.TipoTareaId == tipoTareaId)
                .ToList();
        }

        public List<TaakTarea> GetTareaById(int tareaId)
        {
            return _context.TaakTarea
                .Include(i => i.EstadoTarea)
                .Include(i => i.UsuarioIngreso)
                    .ThenInclude(i => i!.TaakAlumno)
                .Include(i => i.TipoTarea)
                .Where(x => x.TareaId == tareaId)
                .ToList();
        }

        public bool AddTarea(TaakTarea tarea)
        {
            _context.TaakTarea.Add(tarea);
            return _context.SaveChanges() > 0? true : false;
        }
    }
}
