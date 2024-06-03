using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests;
using Application.Requests.Cliente;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Utilities.Exceptions.Exceptions;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IKamRepository _kamRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IMailService _mailService;
        private readonly IUserRepository _userRepository;

        public ClienteService(IKamRepository kamRepository, IClienteRepository clienteRepository, IEmpresaRepository empresaRepository, IAdminRepository adminRepository, IMailService mailService, IUserRepository userRepository)
        {
            _kamRepository = kamRepository;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
            _adminRepository = adminRepository;
            _mailService = mailService;
            _userRepository = userRepository;
        }

        public TaakCliente CreateKam(RegisterClienteRequest cliente)
        {
            ValidateRequest(cliente);

            if (!IsExistAdministrador(cliente.AdministradorId.GetValueOrDefault()))
            {
                throw new ValidationException(MessagesExceptions.IdAdminNotExist);
            }

            if (!IsExistEmpresa(cliente.EmpresaId.GetValueOrDefault()))
            {
                throw new ValidationException(MessagesExceptions.IdEmpresaNotExist);
            }
            // ........
            var passTCNohash = GenerateUniqueToken();
            var newKam = NewTaakKam(cliente, passTCNohash);
            _kamRepository.CreateKam(newKam);

            string titileMsn = "¡Bienvenido a Taak!";
            SendTokenMailClienteAsync(cliente, passTCNohash, titileMsn);

            return newKam.Cliente;
        }
        public TaakCliente UpdateCliente(UpdateClienteRequest cliente)
        {
            ValidateUpdateRequest(cliente);

            var getById = _clienteRepository.GetById(cliente.ClienteId);

            if (getById == null)
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }
            // falta trim
            getById.Nombre = cliente.RazonSocial!;
            getById.Descipcion = cliente.Descipcion!;
            getById.Email = cliente.Email!;
            getById.Telefono = cliente.Telefono;
            getById.Celular = cliente.Celular;

            _clienteRepository.UpdateCliente(getById);

            return getById;
        }
        

        public TaakKam NewTaakKam(RegisterClienteRequest cliente, string passTCNohash)
        {

            var newUsuario = new TaakUsuario()
            {
                Usuario = cliente.Rut!.CleanUserRut(),
                Contrasenia = HashUtils.GetHashFirst(passTCNohash),
                TipoUsuarioId = 2,
            };

            var newCliente = new TaakCliente()
            {
                Nombre = cliente.RazonSocial!,
                Descipcion = cliente.Descipcion!,
                Rut = cliente.Rut!.CleanAlumnoRut(),
                Email = cliente.Email!,
                Telefono = cliente.Telefono,
                Celular = cliente.Celular,
                EmpresaId = (int)cliente.EmpresaId!,
                Usuario =  newUsuario,             
            };

            var newKam = new TaakKam()
            {
                AdministradorId = cliente.AdministradorId.GetValueOrDefault(),
                Cliente = newCliente,
            };

            return newKam;
        }

        public TaakCliente newUpdateCliente(UpdateClienteRequest cliente)
        {
            var upCliente = new TaakCliente()
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.RazonSocial!,
                Descipcion = cliente.Descipcion!,
                Email = cliente.Email!,
                Telefono = cliente.Telefono,
                Celular = cliente.Celular,

            };

            return upCliente;
        }

        //-------------------------------------------------------------------------- Validations
        private void ValidateRequest(RegisterClienteRequest cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.RazonSocial) ||
               string.IsNullOrWhiteSpace(cliente.Descipcion) ||
               string.IsNullOrWhiteSpace(cliente.Rut) ||
               string.IsNullOrWhiteSpace(cliente.Telefono) ||
               string.IsNullOrWhiteSpace(cliente.Celular) ||
               cliente.EmpresaId == 0)
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
            if (IsExistRut(cliente.Rut))
            {
                throw new ValidationException(MessagesExceptions.RutsExist);
            }
            if (IsExistEmail(cliente.Email))
            {
                throw new ValidationException(MessagesExceptions.EmailsExist);
            }
        }

        private void ValidateUpdateRequest(UpdateClienteRequest cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.RazonSocial) ||
               string.IsNullOrWhiteSpace(cliente.Descipcion) ||
               string.IsNullOrWhiteSpace(cliente.Email) ||
               string.IsNullOrWhiteSpace(cliente.Telefono) ||
               string.IsNullOrWhiteSpace(cliente.Celular))  
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }

            if (IsExistEmail(cliente.Email))
            {
                throw new ValidationException(MessagesExceptions.EmailsExist);
            }
        }

        public bool IsExistRut(string rut)
        {
            var rutFormatter = rut.CleanAlumnoRut();
            return _clienteRepository.GetAll().Exists(x => x.Rut == rutFormatter);
        }

        public bool IsExistEmail(string email)
        {
            return _clienteRepository.GetAll().Exists(x => x.Email == email);
        }

        public List<TaakCliente> GetCliente()
        {
            var listaClientes = _clienteRepository.GetAll();
            return listaClientes;
        }

        private bool IsExistAdministrador(int administradorId)
        {
            return _adminRepository.GetAll().Any(kam => kam.AdministradorId == administradorId);
        }

        private bool IsExistEmpresa(int empresaId)
        {
            return _empresaRepository.GetAll().Any(empresa => empresa.EmpresaId == empresaId && empresa.Estado);
        }

        public List<TaakCliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public async Task SendTokenMailClienteAsync(RegisterClienteRequest register, string passTCNohash, string titleMsn)
        {

            var newObject = new
            {
                Contrasenia = passTCNohash,
                loginurl = "https://web.taak.cl"
            };

            string filename = "WelcomeClient.html";
            string htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
            obj: newObject
                );
            _mailService.SendEmailGmail(register.Email!, titleMsn, htmlContent);
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

    }
}
