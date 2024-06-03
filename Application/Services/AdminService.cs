using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests.Admin;
using Application.Requests.Alumno;
using Application.Requests.Cliente;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Utilities.Exceptions.Exceptions;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;


        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IMailService mailService)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _mailService = mailService;
        }

        public async Task CreateAdmin(RegisterAdminRequest admin)
        {
            ValidateRequest(admin);

            var passTCNohash = GenerateUniqueToken();
            var newAdmin = NewTaakAdministrador(admin, passTCNohash);
            _adminRepository.CreateAdmin(newAdmin);

            string titileMsn = "¡Bienvenido a Taak!";
            await SendTokenMailClienteAsync(admin, passTCNohash, titileMsn).ConfigureAwait(false);

        }

        private TaakAdministrador NewTaakAdministrador(RegisterAdminRequest admin, string passTCNohash)
        {
            var newUsuario = new TaakUsuario()
            {
                Usuario = admin.Rut!.CleanUserRut(),
                Contrasenia = HashUtils.GetHashFirst(passTCNohash),
                TipoUsuarioId = 1,
            };


            var newAdmin = new TaakAdministrador()
            {
                PrimerNombre = admin.PrimerNombre!,
                SegundoNombre = admin.SegundoNombre,
                ApellidoPaterno = admin.ApellidoPaterno!,
                ApellidoMaterno = admin.ApellidoMaterno!,
                Rut = admin.Rut!.CleanAlumnoRut(),
                Email = admin.Email!,
                Telefono = admin.Telefono!,
                Usuario = newUsuario
            };
            return newAdmin;           
        }

        private void ValidateRequest(RegisterAdminRequest admin)
        {
            if (string.IsNullOrWhiteSpace(admin.PrimerNombre) ||
               string.IsNullOrWhiteSpace(admin.ApellidoPaterno) ||
               string.IsNullOrWhiteSpace(admin.ApellidoMaterno) ||
               string.IsNullOrWhiteSpace(admin.Rut) ||
               string.IsNullOrWhiteSpace(admin.Email) ||
               string.IsNullOrWhiteSpace(admin.Telefono))
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
            if (IsExistRut(admin.Rut))
            {
                throw new ValidationException(MessagesExceptions.RutsExist);
            }
            if (IsExistEmail(admin.Email))
            {
                throw new ValidationException(MessagesExceptions.EmailsExist);
            }
        }

        public bool IsExistRut(string rut)
        {
            var rutFormatter = rut.CleanAlumnoRut();
            return _adminRepository.GetAll().Exists(x => x.Rut == rutFormatter);
        }

        public bool IsExistEmail(string email)
        {
            return _adminRepository.GetAll().Exists(x => x.Email == email);
        }

        public List<TaakAdministrador> GetAdmin()
        {
            return _adminRepository.GetAll();
        }

        private string GenerateUniqueToken()
        {
            string passNoHash;
            string passHashed;
            TaakUsuario existingToken;

            do
            {
                passNoHash = HashUtils.GenerateRandomToken(8);

                passHashed = HashUtils.GetHashFirst(passNoHash);

                existingToken = _userRepository.GetAll().FirstOrDefault(x => x.Contrasenia == passHashed);

            } while (existingToken != null);

            return passNoHash;
        }

        public async Task SendTokenMailClienteAsync(RegisterAdminRequest admin, string passTCNohash, string titleMsn)
        {

            var newObject = new
            {
                Contrasenia = passTCNohash,
                loginurl = "https://web.taak.cl"
            };

            String filename = "WelcomeAdmin.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
            obj: newObject
                );
            _mailService.SendEmailGmail(admin.Email!, titleMsn, htmlContent);
        }
    }
    
}
