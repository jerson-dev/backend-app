using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITokenCorreoRepository
    {
        public void CreateTokenCorreo(TaakTokenCorreo tokenCorreo);

        public TaakTokenCorreo GetByEmail(string email);

        public void UpdateToken(TaakTokenCorreo tokenCorreo);

        public List<TaakTokenCorreo> GetAll();
    }
}
