using Application.Interfaces;
using Application.Interfaces.Utilities;
using Application.Requests.Alumno;
using Application.Requests.Cliente;
using Application.Responses.Alumno;
using Application.Responses.Anuncio;
using Application.Utilities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
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
    public class AlumnoService : IAlumnoService
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IDominioRepository _dominioRepository; 
        private readonly IMailService _mailService;

        public AlumnoService(IAlumnoRepository alumnoRepository, IDominioRepository dominioRepository, IMailService mailService) // new code)
        {
            _alumnoRepository = alumnoRepository;
            _dominioRepository = dominioRepository; 
            _mailService = mailService;
        }

        public async Task<AlumnoResponse> CreateAlumno(RegisterAlumnoRequest alumno)
        {
            ValidateRequest(alumno);

            ValidateEmail(alumno.Email!);

            var newAlumno = NewTaakAlumno(alumno);

            _alumnoRepository.CreateAlumno(newAlumno);

            string titileMsn = "¡Bienvenido a Taak!";
            await SendStudentMail(alumno, titileMsn).ConfigureAwait(false);

            return ConvertToAlumnoResponse(newAlumno); 
        }

        public bool UpdateDatosAlumnoDireccion(int id, UpdateAlumnoRequestDireccion alumnoRequest)
        {
            ValidateUpdateRequestDireccion(alumnoRequest);

            var getById = _alumnoRepository.GetById(id);

            if (getById == null)
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            getById.Direccion = alumnoRequest.Direccion;

            var response = _alumnoRepository.UpdateDatosAlumnoDireccion(getById);
            return response;
        }

        public bool UpdateDatosAlumnoContacto(int id, UpdateAlumnoRequestContacto alumnoRequest)
        {
            ValidateUpdateRequestContacto(alumnoRequest);

            var getById = _alumnoRepository.GetById(id);

            if (getById == null)
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            getById.Email = alumnoRequest.Email;
            getById.Telefono = alumnoRequest.Telefono;

            _alumnoRepository.UpdateDatosAlumnoContacto(getById);

            var response = _alumnoRepository.UpdateDatosAlumnoContacto(getById);
            return response;
        }

        public bool UpdateDatosAlumnoAcademico(int id, UpdateAlumnoRequestAcademico alumnoRequest)
        {
            ValidateUpdateRequestAcademico(alumnoRequest);

            var getById = _alumnoRepository.GetById(id);

            if (getById == null)
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            getById.CarreraId = alumnoRequest.CarreraId;
            getById.Carrera = new TaakCarrera { CarreraId = alumnoRequest.CarreraId, Carrera = alumnoRequest.Carrera };
            getById.CasaEstudioId = alumnoRequest.CasaEstudioId;
            getById.CasaEstudio = new TaakCasaEstudio { CasaEstudioId = alumnoRequest.CasaEstudioId, CasaEstudio = alumnoRequest.CasaEstudio };

            var response = _alumnoRepository.UpdateDatosAlumnoContacto(getById);
            return response;
        }

        //public TaakAlumno UpdateDatosAlumnoAcademico(UpdateAlumnoRequest alumno)
        //{
        //    ValidateUpdateRequest(alumno);

        //    var getById = _alumnoRepository.GetById(alumno.UsuarioId);

        //    if (getById == null)
        //    {
        //        throw new ValidationException(MessagesExceptions.IdDoesntExist);
        //    }

        //    getById.Direccion = alumno.Direccion;

        //    _alumnoRepository.UpdateDatosAlumnoAcademico(getById);

        //    return getById;
        //}

        //public TaakAlumno UpdateDatosAlumnoBancarios(UpdateAlumnoRequest alumno)
        //{
        //    ValidateUpdateRequest(alumno);

        //    var getById = _alumnoRepository.GetById(alumno.UsuarioId);

        //    if (getById == null)
        //    {
        //        throw new ValidationException(MessagesExceptions.IdDoesntExist);
        //    }

        //    getById.Direccion = alumno.Direccion;

        //    _alumnoRepository.UpdateDatosAlumnoBancarios(getById);

        //    return getById;
        //}

        public AlumnoResponse ConvertToAlumnoResponse(TaakAlumno alumno)
        {
            return new AlumnoResponse
            {
                AlumnoId = alumno.AlumnoId,
                PrimerNombre = alumno.PrimerNombre,
                UsuarioId = alumno.UsuarioId,
            };
        }
        private TaakAlumno NewTaakAlumno(RegisterAlumnoRequest alumno)
        {

            var newUser = new TaakUsuario()
            {
                Usuario = alumno.Rut!.CleanUserRut(),
                Contrasenia = HashUtils.GetHashFirst(alumno.Contrasenia!),
                TipoUsuarioId = 3,
            };


            var newAlumno = new TaakAlumno()
            {
                PrimerNombre = alumno.Nombre!,
                SegundoNombre = alumno.SegundoNombre,
                ApellidoPaterno = alumno.Apellido!,
                ApellidoMaterno = alumno.SegundoApellido!,
                FechaNacimiento = alumno.FechaNacimiento!.GetValueOrDefault(),
                Rut = alumno.Rut!.CleanAlumnoRut(),
                Region = alumno.Region!,
                Ciudad = alumno.Ciudad!,
                Comuna = alumno.Comuna!,
                Direccion = alumno.Direccion!,
                Numero = alumno.Numero!,
                NumeroDpto = alumno.NroDpto,
                Email = alumno.Email!,
                Telefono = alumno.Telefono!,
                AnioCurso = alumno.AnioCurso!,
                Latitud = alumno.Latitud!,
                Longitud = alumno.Longitud!,
                CarreraId = alumno.CarreraId,
                CasaEstudioId = alumno.CasaEstudioId,
                ProspectoId = alumno.ProspectoId,
                Usuario = newUser
            };
            return newAlumno;
        }

        public List<TaakAlumno> GetAlumnosByUserId(int userId)
        {
            var alumnos = _alumnoRepository.GetAlumnosByUserId(userId);

            if (alumnos.IsNullOrEmpty() || !alumnos.Any())
            {
                throw new ValidationException(MessagesExceptions.IdUserNotExist);
            }

            return alumnos;
        }

        public List<AlumnoResponse> BuildAlumnoResponse(IEnumerable<TaakAlumno> alumnos)
        {
            return alumnos.Select(alumno => new AlumnoResponse
            {
                AlumnoId = alumno.AlumnoId,
                PrimerNombre = alumno.PrimerNombre,
                SegundoNombre = alumno.SegundoNombre,
                ApellidoPaterno = alumno.ApellidoPaterno,
                ApellidoMaterno = alumno.ApellidoMaterno,
                Rut = alumno.Rut,
                Region = alumno.Region,
                Ciudad = alumno.Ciudad,
                Comuna = alumno.Comuna,
                Direccion = alumno.Direccion,
                Numero = alumno.Numero,
                NumeroDpto = alumno.NumeroDpto,
                Longitud = alumno.Longitud,
                Latitud = alumno.Latitud,
                Email = alumno.Email,
                Telefono = alumno.Telefono,
                AnioCurso = alumno.AnioCurso,
                FechaNacimiento = alumno.FechaNacimiento,
                CasaEstudioId = alumno.CasaEstudioId,
                CarreraId = alumno.CarreraId,
                DatoBancarioId = alumno.DatoBancarioId,
                UsuarioId = alumno.UsuarioId,
                ProspectoId = alumno.ProspectoId

            }).ToList();
        }

        /*-------------------------------VALIDACIONES---------------------------*/
        private void ValidateRequest(RegisterAlumnoRequest alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Nombre) ||
               string.IsNullOrWhiteSpace(alumno.Apellido) ||
               string.IsNullOrWhiteSpace(alumno.SegundoApellido) ||
               string.IsNullOrWhiteSpace(alumno.Rut) ||
               string.IsNullOrWhiteSpace(alumno.Direccion) ||
               string.IsNullOrWhiteSpace(alumno.Email) ||
               string.IsNullOrWhiteSpace(alumno.Telefono) ||
               string.IsNullOrWhiteSpace(alumno.AnioCurso) ||
               alumno.CarreraId == 0 ||
               alumno.CasaEstudioId == 0) 
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
            if (IsExistRut(alumno.Rut))
            {
                throw new ValidationException(MessagesExceptions.RutsExist);
            }
            if (IsExistEmail(alumno.Email))
            {
                throw new ValidationException(MessagesExceptions.EmailsExist);
            }
        }

        private void ValidateEmail(string email) 
        {
            var domain = email.Split('@').LastOrDefault();

            var allDominios = _dominioRepository.GetAllDominios();
            if (!allDominios.Exists(d => d.Dominio.Equals("@" + domain, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ValidationException(MessagesExceptions.DominioNotPermitted);
            }
        }

        private void ValidateUpdateRequestDireccion(UpdateAlumnoRequestDireccion alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Direccion))
               
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
        }

        private void ValidateUpdateRequestContacto(UpdateAlumnoRequestContacto alumno)
        {
            if (string.IsNullOrWhiteSpace(alumno.Email) ||
                string.IsNullOrWhiteSpace(alumno.Telefono))

            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }

            if (IsExistEmail(alumno.Email))
            {
                throw new ValidationException(MessagesExceptions.EmailsExist);
            }
        }

        private void ValidateUpdateRequestAcademico(UpdateAlumnoRequestAcademico alumno)
        {
            if (alumno.CarreraId <= 0 || alumno.CasaEstudioId <=0)
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
        }

        public bool IsExistRut(string rut)
        {
            var rutFormatter = rut.CleanAlumnoRut();            
            return _alumnoRepository.GetAll().Exists(x => x.Rut == rutFormatter);
        }

        public bool IsExistEmail(string email)
        {
            return _alumnoRepository.GetAll().Exists(x => x.Email == email);
        }


        public async Task SendStudentMail(RegisterAlumnoRequest alumno, string titleMsn)
        {
            var newObject = new
            {
                PrimerNombre = alumno.Nombre,
                ApellidoPaterno = alumno.Apellido,
                ApellidoMaterno = alumno.SegundoApellido
            };

            String filename = "WelcomeStudent.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: newObject
                );
            _mailService.SendEmailGmail(alumno.Email!, titleMsn, htmlContent);
        }




        public void SendWelcomeMail()
        {
            var props = new
            {
                code = "KGIEJD",
                PrimerNombre = "Sergio",
                ApellidoPaterno = "Leiva",
                ApellidoMaterno = "González"
            };
            WelcomeStudentMail(props);
            WelcomeClientMailAsync(props);
            WelcomeAdministratorMailAsync(props);
            EditPasswordMailAsync(props);
            ConfirmMailAsync(props);
        }

        private void WelcomeStudentMail(dynamic obj)
        {
            String filename = "WelcomeStudent.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: _mailService.getHtmlFileAsync(filename), 
                obj: obj
            );
            _mailService.SendEmailGmail("sleiva@acl.cl", "Bienvenido estudiante a la plataforma Taak", htmlContent);
        }
        
        private async Task WelcomeClientMailAsync(dynamic obj)
        {
            String filename = "WelcomeClient.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: obj
            );
            _mailService.SendEmailGmail("dev.brsanchez@gmail.com", "Bienvenido a la plataforma Taak", htmlContent);
        }
        
        private async Task WelcomeAdministratorMailAsync(dynamic obj)
        {
            String filename = "WelcomeAdmin.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: obj
            );
            _mailService.SendEmailGmail("dev.brsanchez@gmail.com", "Bienvenido administrador a la plataforma Taak", htmlContent);
        }
        
        private async Task ConfirmMailAsync(dynamic obj)
        {
            String filename = "ConfirmEmail.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: obj
            );
            _mailService.SendEmailGmail("dev.brsanchez@gmail.com", "Confirmación de correo electronico Taak", htmlContent);
        }
        
        private async Task EditPasswordMailAsync(dynamic obj)
        {
            String filename = "EditPassword.html";
            String htmlContent = MailService.ReplaceWithObjectProperties(
                template: await _mailService.getHtmlFileAsync(filename).ConfigureAwait(false),
                obj: obj
            );
            _mailService.SendEmailGmail("dev.brsanchez@gmail.com", "Solicitud cambio de contraseña Taak", htmlContent);
        }

    }
}
