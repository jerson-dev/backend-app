using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateContacto(TaakSolicitudContacto contacto)
        {
            _context.TaakSolicitudContacto.Add(contacto);
            _context.SaveChanges();
        }
    }
}
