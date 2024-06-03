using Application.Interfaces;
using Application.Responses.Tarea;
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
    public class TareaService : ITareaService
    {
        private readonly ITareaRepository _tareaRepository;
        private readonly IUserRepository _userRepository;

        public TareaService(ITareaRepository tareaRepository, IUserRepository userRepository)
        {
            _tareaRepository = tareaRepository;
            _userRepository = userRepository;
        }

        public List<TareaResponse> GetTareaByTipoTareaId(int tipoTareaId)
        {
            var tareaByTipoTarea = _tareaRepository.GetTareaByTipoTareaId(tipoTareaId);

            if (tareaByTipoTarea == null || !tareaByTipoTarea.Any())
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            var response = tareaByTipoTarea.Select(x => new TareaResponse
            {
                TareaId = x.TareaId,
                FechaCreacion = x.FechaCreacion,
                FechaGestion = x.FechaGestion,
                UsuarioIngresoId = x.UsuarioIngresoId,
                UsuarioGestionId = x.UsuarioGestionId,
                TipoTareaId = x.TipoTareaId,
                EstadoTareaId = x.EstadoTareaId,

            }).ToList();

            return response;
        }

        public List<TareaResponse> GetTareaById(int tareaId)
        {
            var tarea = _tareaRepository.GetTareaById(tareaId);

            if (tarea == null || !tarea.Any())
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            var response = tarea.Select(x => new TareaResponse
            {
                TareaId = x.TareaId,
                FechaCreacion = x.FechaCreacion,
                FechaGestion = x.FechaGestion,
                UsuarioIngresoId = x.UsuarioIngresoId,
                NombreIngreso = $"{x.UsuarioIngreso!.TaakAlumno!.PrimerNombre} {x.UsuarioIngreso.TaakAlumno.SegundoNombre} {x.UsuarioIngreso.TaakAlumno.ApellidoPaterno} {x.UsuarioIngreso.TaakAlumno.ApellidoMaterno}",
                RutIngreso = x.UsuarioIngreso.Usuario,
                UsuarioGestionId = x.UsuarioGestionId,
                TipoTareaId = x.TipoTareaId,
                TipoTarea = x.TipoTarea!.TipoTarea,
                EstadoTareaId = x.EstadoTareaId,
                Estado = x.EstadoTarea!.EstadoTarea

            }).ToList();

            return response;
        }

        public bool AddTareaEnrolamiento(int tipoEnrolamientoId, int usuarioId)
        {
            TaakTarea tarea = new();

            tarea.EstadoTareaId = 1;
            tarea.TipoTareaId = 1;
            tarea.UsuarioIngresoId = usuarioId;
            tarea.FechaCreacion = DateTime.Now;

            TaakEnrolamiento taakEnrolamiento = new();

            taakEnrolamiento.TipoEnrolamientoId = tipoEnrolamientoId;

            tarea.LstEnrolamiento = new();
            tarea.LstEnrolamiento!.Add(taakEnrolamiento);

            _tareaRepository.AddTarea(tarea);

            return true;
        }
    }
}
