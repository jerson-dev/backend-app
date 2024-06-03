using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Utilities
{
    public interface IFTPService
    {
        public (string? FtpUrl, string? FtpUsername, string? FtpPassword) GetFtpCredentials();

        public Task<byte[]> getFTPFileAsync(string pathAndFilename);
    }
}
