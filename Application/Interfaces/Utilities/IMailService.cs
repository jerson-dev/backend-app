using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Utilities
{
    public interface IMailService
    {
        public void SendEmailGmail(String receptor, String asunto, String mensaje);

        Task<string> getHtmlFileAsync(String filename);
    }
}
