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
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateAdmin(TaakAdministrador admin)
        {
            _context.TaakAdministrador.Add(admin);
            _context.SaveChanges();
        }

        public List<TaakAdministrador> GetAll()
        {
            return _context.TaakAdministrador
                .Include(a => a.lstKam!)
                .Include(a => a.Usuario)
                .ToList();
        }

        public List<TaakAdministrador> GetAdminsByContactStatus(bool isContacto)
        {
            return _context.TaakAdministrador.Where(a=> a.IsContacto == isContacto).ToList();
        }

        public TaakAdministrador GetAdmin()
        {
            return _context.TaakAdministrador.FirstOrDefault();
        }
    }
}
