using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MotivoRepository : IMotivoRepository
    {
        private readonly ApplicationDbContext _context;

        public MotivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<TaakSolicitudMotivo> GetMotivo() // solo traer todos los motivos es estado == true
        {
            return _context.TaakSolicitudMotivo.Where(e => e.Estado == true).ToList();
        }

        public TaakSolicitudMotivo GetMotivoById(int MotivoId)
        {
            return _context.TaakSolicitudMotivo.FirstOrDefault(m => m.Estado && m.MotivoId == MotivoId);
        }
    }
}
