using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FileService : IFileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IFTPService _FTPService;
        
        public FileService(IUserRepository userRepository, IDocumentoRepository documentoRepository, IFTPService fTPService)
        {
            _userRepository = userRepository;
            _documentoRepository = documentoRepository;
            _FTPService = fTPService;
        }

        private static readonly Regex AllowedImageFileTypes = new Regex(@"^(image/jpeg|image/png)$", RegexOptions.IgnoreCase);

        public async Task<string> UploadImageFile(IFormFile file, int userId)
        {

            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("El archivo no ha sido cargado o está vacío.");
            }


            if (!AllowedImageFileTypes.IsMatch(file.ContentType))
            {
                throw new ArgumentException("Formato no permitido.");
            }

            // Validar y ajustar la ruta del destino

            var searchUser = _userRepository.GetUserById(userId);

            if (searchUser == null || searchUser.TipoUsuarioId == 1)
            {
                throw new ArgumentException("El ID ingresado no existe");
            }

            string remoteFolder = "";

            if (searchUser.TipoUsuarioId == 3)
            {
                remoteFolder = "Alumno/Logo";
            }

            if (searchUser.TipoUsuarioId == 2)
            {
                remoteFolder = "Cliente/Logo";
            }

            string fileName = searchUser.Usuario;

            bool isUploaded = await UploadFileFTP(file, remoteFolder, fileName);

            if (isUploaded)
            {

                string fileExtension = Path.GetExtension(file.FileName);

                string uniqueFileName = $"{fileName}{fileExtension}";

                string filePath = $"{remoteFolder}/{uniqueFileName}";//de prueba

                string filepathBD = $"{remoteFolder}/{uniqueFileName}";

                var documento = new TaakDocumento
                {
                    FileName = uniqueFileName,
                    FilePath = filepathBD,
                    FileExtension = fileExtension,
                    FileType = file.ContentType,
                    TipoDocumentoId = 1,
                    UsuarioId = userId,
                };

                bool isDocumentCreated = _documentoRepository.createDocumento(documento);

                if (isDocumentCreated)
                {
                    return filePath;//de prueba
                }
                else
                {
                    throw new Exception("Error al crear el documento en la base de datos.");
                }

            }
            else
            {
                throw new Exception("Error al cargar el archivo al FTP");
            }
        }



        private async Task<bool> UploadFileFTP(IFormFile file, string remoteFolder, string fileName)
        {
            var (ftpUrl, ftpUsername, ftpPassword) = _FTPService.GetFtpCredentials();

            string fileExtension = Path.GetExtension(file.FileName);

            string uniqueFileName = $"{fileName}{fileExtension}";

            string filePath = $"{ftpUrl}/{remoteFolder}/{uniqueFileName}";

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var request = (FtpWebRequest)WebRequest.Create(filePath);

                    request.Method = WebRequestMethods.Ftp.UploadFile;

                    request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                    using (var ftpStream = await request.GetRequestStreamAsync())
                    {
                        await stream.CopyToAsync(ftpStream);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<(byte[] FileData, string FileType)> GetProfileImage(int userId)
        {
            var document = _documentoRepository.getProfileImageById(userId);
            if (document == null)
            {
                throw new ArgumentException("El ID ingresado no existe");
            }

            string fileType = document.FileType;

            string pathAndFilename = document.FilePath;
            byte[] fileData = await _FTPService.getFTPFileAsync(pathAndFilename);

            return (fileData, fileType);
        }

        //public async Task<string> UploadEnrolamientoFile(IFormFile file, int userId, tipoEnrolamientoId)
    }
}
