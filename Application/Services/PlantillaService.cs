using Application.Interfaces;
using Application.Requests.Plantilla;
using Application.Responses.Plantilla;
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
    public class PlantillaService : IPlantillaService
    {
        private readonly IPlantillaRepository _plantillaRepository;
        private readonly IKamRepository _kamRepository;
        private readonly ITipoPlantillaRepository _tipoPlantillaRepository;

        public PlantillaService(IPlantillaRepository plantillaRepository, IKamRepository kamRepository, ITipoPlantillaRepository tipoPlantillaRepository)
        {
            _plantillaRepository = plantillaRepository;
            _kamRepository = kamRepository;
            _tipoPlantillaRepository = tipoPlantillaRepository;
        }

        public void CreatePlantilla(RegisterPlantillaRequest plantilla)
        {
            ValidatePlantillaRequest(plantilla);
            var IdCliente = getIdCliente(plantilla.KamId);
            var newPlantilla = newTaakPlantilla(plantilla, IdCliente);
            _plantillaRepository.CreatePlantilla(newPlantilla);
        }

        private TaakPlantilla newTaakPlantilla(RegisterPlantillaRequest plantillaRequest, int id)
        {
            var newPlantilla = new TaakPlantilla()
            {
                Titulo = plantillaRequest.Titulo,
                Descipcion = plantillaRequest.Descipcion,
                Requisitos = plantillaRequest.Requisitos,
                ClienteId = id,
                TipoPlantillaId = plantillaRequest.TipoPlantillaId,
                KamId = plantillaRequest.KamId
            };

            return newPlantilla;
        }
        public bool UpdatePlantilla(int id, UpdatePlantillaRequest plantillaRequest)
        {
            var getById = _plantillaRepository.GetPlantilla(id);

            if (getById == null)
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            if (!IsExistTipoPlan(plantillaRequest.TipoPlantillaId))
            {
                throw new ValidationException(MessagesExceptions.IdTipoPlantillaNotExist);
            }

            getById.Titulo = plantillaRequest.Titulo;
            getById.Descipcion = plantillaRequest.Descipcion;
            getById.Requisitos = plantillaRequest.Requisitos;
            getById.TipoPlantillaId = plantillaRequest.TipoPlantillaId;

            var respose = _plantillaRepository.UpdatePlantilla(getById);

            if (!respose)
            {
                return false;
            }

            return true;
        }

        private void ValidatePlantillaRequest(RegisterPlantillaRequest plantillaRequest)
        {
            if (string.IsNullOrWhiteSpace(plantillaRequest.Titulo) ||
               string.IsNullOrWhiteSpace(plantillaRequest.Descipcion) ||
               string.IsNullOrWhiteSpace(plantillaRequest.Requisitos))
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }

            if (!IsExistTipoPlan(plantillaRequest.TipoPlantillaId))
            {
                throw new ValidationException(MessagesExceptions.IdTipoPlantillaNotExist);
            }
        }

        public int getIdCliente(int idkam)
        {
            var getKam = _kamRepository.GetKamById(idkam);

            if (getKam == null)
            {
                throw new ValidationException(MessagesExceptions.IdKamNotExist);
            }

            var idCliente = getKam.ClienteId;

            return idCliente;
        }

        public bool IsExistTipoPlan(int idTipoPlantilla)
        {
            return _tipoPlantillaRepository.GetTipoPlantillaId(idTipoPlantilla) != null ? true : false;
        }

        public List<TaakPlantilla> GetAllPlantillas()
        {
            var listaCarreras = _plantillaRepository.GetAllPlantillas();
            return listaCarreras;
        }

        public List<PlantillaResponse> GetPlantillaByClienteId(int clienteId)
        {
            var plantillasCliente = _plantillaRepository.GetPlantillaByClienteId(clienteId);

            if (plantillasCliente == null || !plantillasCliente.Any())
            {
                throw new ValidationException(MessagesExceptions.IdDoesntExist);
            }

            var response = plantillasCliente.Select(plantilla => new PlantillaResponse
            {
                PlantillaId = plantilla.PlantillaId,
                Titulo = plantilla.Titulo,
                Descipcion = plantilla.Descipcion,
                Requisitos = plantilla.Requisitos,
                ClienteId = plantilla.ClienteId,
                TipoPlantillaId = plantilla.TipoPlantillaId,
                TipoPlantilla = plantilla.TipoPlantilla?.TipoPlantilla,
                KamId = plantilla.KamId,

            }).ToList();

            return response;
        }

    }
}


