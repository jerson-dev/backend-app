using Application.Interfaces.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class FTPService : IFTPService
    {
        private readonly IConfiguration _configuration;

        public FTPService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string? FtpUrl, string? FtpUsername, string? FtpPassword) GetFtpCredentials()
        {
            string? ftpUrl = _configuration["FTPSettings:Host"];
            string? ftpUsername = _configuration["FTPSettings:Username"];
            string? ftpPassword = _configuration["FTPSettings:Password"];

            return (ftpUrl, ftpUsername, ftpPassword);
        }

        public async Task<byte[]> getFTPFileAsync(string pathAndFilename)
        {
            var (ftpUrl, ftpUsername, ftpPassword) = GetFtpCredentials();

            string fullPath = $"{ftpUrl}{pathAndFilename}";

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                byte[] fileData = await client.DownloadDataTaskAsync(fullPath);

                return fileData;
            }
        }
    }
}
