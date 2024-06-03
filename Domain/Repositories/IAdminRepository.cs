using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAdminRepository
    {
        public void CreateAdmin(TaakAdministrador admin);

        public List<TaakAdministrador> GetAll();

        public TaakAdministrador GetAdmin();

        public List<TaakAdministrador> GetAdminsByContactStatus(bool isContacto);
    }
}
