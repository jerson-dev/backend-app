using Application.Requests.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Utilities
{
    public interface IAuthService
    {
        public string AuthenticateAdmin(AuthenticateRequest request);
        public string AuthenticateCliente(AuthenticateRequest request);
        public string AuthenticateAlumno(AuthenticateRequest request);
        public (string, int) Authenticate(AuthenticateRequest request, int? roleId = null);
        public bool ValidateAuthenticate(string token, int userId);


        public bool IsAuthenticated();
    }
}
