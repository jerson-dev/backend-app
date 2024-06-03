using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class KamRepository : IKamRepository
    {
        private readonly ApplicationDbContext _context;

        public KamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateKam(TaakKam kam)
        {
            _context.TaakKam.Add(kam);
            _context.SaveChanges();
        }

        public List<TaakKam> GetAll()
        {
            return _context.TaakKam.ToList();
        }

        public TaakKam? GetKamById(int idKam) 
        {
            return _context.TaakKam.Where(x => x.Id == idKam).FirstOrDefault();
        }
    }
}
