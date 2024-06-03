 using Application.Requests.Admin;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        public Task CreateAdmin(RegisterAdminRequest newAdmin);
        public bool IsExistRut(string rut);
        public bool IsExistEmail(string email);
        public List<TaakAdministrador> GetAdmin();
    }
}
