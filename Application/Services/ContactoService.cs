using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests.Contacto;
using Domain.Models;
using Domain.Repositories;
using System.ComponentModel.DataAnnotations;
using static Application.Utilities.Exceptions.Exceptions;

namespace Application.Services
{
    public class ContactoService : IContactoService
    {
        private readonly IContactoRepository _contactoRepository;
        private readonly IMotivoRepository _motivoRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IMailService _mailService;

        public ContactoService(IContactoRepository contactoRepository, IMotivoRepository motivoRepository, IAdminRepository adminRepository, IMailService mailService)
        {
            _contactoRepository = contactoRepository;
            _motivoRepository = motivoRepository;
            _adminRepository = adminRepository;
            _mailService = mailService;
        }

        public void CreateContacto(RegisterContactoRequest contacto)
        {
            var motivo = _motivoRepository.GetMotivoById(contacto.MotivoId);

            if (motivo != null)
            {
                // Agregar nuevo contacto
                var newContacto = NewTaakSolicitudContacto(contacto);
                _contactoRepository.CreateContacto(newContacto);

                // Obtener la lista de administradores en estado IsContact en true
                var administradores = _adminRepository.GetAdminsByContactStatus(true);

                // Encapsular en un método privado y llamar aquí

                if (administradores.Any())
                {
                    // Obtener los correos electrónicos de todos los administradores con IsContacto == true
                    var receptores = administradores.Select(a => a.Email).ToList();

                    // Agregando cuerpo del Email
                    var asunto = "Nuevo contacto registrado";
                    var mensaje = $"Se ha registrado un nuevo contacto con el siguiente correo: {contacto.Email} y teléfono: {contacto.Telefono}\nConsulta: {contacto.Consulta} "; //flag agregar consulta de la Request de Contacto

                    // Enviar correos electrónicos a cada uno de los receptores
                    foreach (var receptor in receptores)
                    {
                        _mailService.SendEmailGmail(receptor, asunto, mensaje);
                    }
                }
                //else
                //{
                //    throw new ValidationException(MessagesExceptions.AdminNotFoundException);
                //}

                //flag: Podrían añadirse más receptores desde el ´mailService.cs´ (a futuro)...

            }
            else
            {
                throw new ValidationException(MessagesExceptions.MotivoNotFoundException); // ✔️✔️
            }

        }

        private TaakSolicitudContacto NewTaakSolicitudContacto(RegisterContactoRequest contacto)
        {
            var newContacto = new TaakSolicitudContacto()
            {
                Email = contacto.Email!,
                Telefono = contacto.Telefono!,
                Consulta = contacto.Consulta!,
                MotivoId = contacto.MotivoId
            };
            return newContacto;
        }
    }
}
