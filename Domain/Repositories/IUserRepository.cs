using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public List<TaakUsuario> GetAll();

        public TaakUsuario? GetUserById(int id);
    }
}
