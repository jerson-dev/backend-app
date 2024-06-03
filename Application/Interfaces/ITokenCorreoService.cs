using Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITokenCorreoService
    {
        public Task CreateTokenCorreoAsync(RegisterTokenCorreoRequest newTokenCorreo);
        public bool IsExistEmail(string email);
        public bool IsExistToken(string email, string token);
        public Task SendTokenMailAsync(RegisterTokenCorreoRequest register, string passTCNohash, string titleMsn);
    }
}
