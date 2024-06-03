using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadImageFile(IFormFile file, int userId);

        public Task<(byte[] FileData, string FileType)> GetProfileImage(int userId);
    }
}
