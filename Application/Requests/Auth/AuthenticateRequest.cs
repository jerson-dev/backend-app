using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Auth
{
    public class AuthenticateRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
