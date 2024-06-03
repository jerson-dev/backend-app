using Application.Interfaces;
using Application.Requests.Anuncio;
using Application.Responses;
using Application.Responses.Anuncio;
using Domain.Models;
using Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Application.Utilities.Exceptions.Exceptions;

namespace Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IPlantillaRepository _plantillaRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository, IPlantillaRepository plantillaRepository)
        {
            _anuncioRepository = anuncioRepository;
            _plantillaRepository = plantillaRepository;
        }
        public List<TaakAnuncio> GetAnuncios()
        {
            var listaAnuncios = _anuncioRepository.GetAnuncio();
            return listaAnuncios;
        }

        public void CreateAnuncio(RegisterAnuncioRequest anuncio)
        {
            if (!IsExistPlantilla(anuncio.PlantillaId))
            {
                throw new ValidationException(MessagesExceptions.IdPlantillaNotExist);
            }

            ValidateRequest(anuncio);

            var newAnuncio = NewTaakAnuncio(anuncio);
            _anuncioRepository.CreateAnuncio(newAnuncio);
        }

        private TaakAnuncio NewTaakAnuncio(RegisterAnuncioRequest anuncio)
        {
            var newAnuncio = new TaakAnuncio()
            {
                DiaServicio = anuncio.DiaServicio,
                JornadaInicio = anuncio.JornadaInicio,
                JornadaTermino = anuncio.JornadaTermino,
                MontoPagar = anuncio.MontoPagar,
                Descripcion = anuncio.Descripcion,
                Region = anuncio.Region,
                Ciudad = anuncio.Ciudad,
                Comuna = anuncio.Comuna,
                Direccion = anuncio.Direccion,
                Numero = anuncio.Numero,
                NumeroDpto = anuncio.NumeroDpto,
                Longitud = anuncio.Longitud,
                Latitud = anuncio.Latitud,
                PlantillaId = anuncio.PlantillaId
            };

            return newAnuncio;
        }

        public List<AnuncioResponse> GetAnuncioByBusqueda(string texto)
        {
            var anuncios = _anuncioRepository.GetAnuncioByBusqueda(texto);

            if (anuncios == null || !anuncios.Any())
            {
               throw new ValidationException(MessagesExceptions.NoAnunciosFound);
   
            }

            return BuildAnuncioResponse(anuncios);
        }

        public List<TaakAnuncio> GetAnunciosByClienteId(int clienteId)
        {
            var anuncios = _anuncioRepository.GetAnunciosByClienteId(clienteId);

            if (anuncios.IsNullOrEmpty() || !anuncios.Any())
            {
                throw new ValidationException(MessagesExceptions.IdClienteNotExist);
            }

            return anuncios;
        }

        public List<AnuncioResponse> BuildAnuncioResponse(IEnumerable<TaakAnuncio> anuncios)
        {
            return anuncios.Select(anuncio => new AnuncioResponse
            {
                AnuncioId = anuncio.AnuncioId,
                DiaServicio = anuncio.DiaServicio!.ToString(),
                JornadaInicio = anuncio.JornadaInicio,
                JornadaTermino = anuncio.JornadaTermino,
                MontoPagar = anuncio.MontoPagar,
                Descripcion = anuncio.Descripcion,
                Region = anuncio.Region,
                Ciudad = anuncio.Ciudad,
                Comuna = anuncio.Comuna,
                Direccion = anuncio.Direccion,
                Numero = anuncio.Numero,
                NumeroDpto = anuncio.NumeroDpto,
                Longitud = anuncio.Longitud,
                Latitud = anuncio.Latitud,
                PlantillaTitulo = anuncio.Plantilla!.Titulo,
                PlantillaDescripcion = anuncio.Plantilla!.Descipcion,
                PlantillaRequisitos = anuncio.Plantilla!.Requisitos,
                NombreCliente = anuncio.Plantilla.Cliente!.Nombre,
                TipoPlantilla = anuncio.Plantilla.TipoPlantilla!.TipoPlantilla

            }).ToList();
        }

        //-------------------------------------------------------------------------- Validations

        private void ValidateRequest(RegisterAnuncioRequest anuncio)
        {
            if (string.IsNullOrWhiteSpace(anuncio.DiaServicio) ||
               !anuncio.JornadaInicio.HasValue ||
               !anuncio.JornadaTermino.HasValue ||
               decimal.IsNegative((decimal)anuncio.MontoPagar!) ||
               string.IsNullOrWhiteSpace(anuncio.Descripcion) ||
               string.IsNullOrWhiteSpace(anuncio.Region) ||
               string.IsNullOrWhiteSpace(anuncio.Ciudad) ||
               string.IsNullOrWhiteSpace(anuncio.Comuna) ||
               string.IsNullOrWhiteSpace(anuncio.Direccion) ||
               string.IsNullOrWhiteSpace(anuncio.Numero) ||
               string.IsNullOrWhiteSpace(anuncio.Longitud) ||
               string.IsNullOrWhiteSpace(anuncio.Latitud) ||
               anuncio.PlantillaId == 0)
            {
                throw new ValidationException(MessagesExceptions.FieldsRequired);
            }
        }

        private bool IsExistPlantilla(int plantillaId)
        {
            return _plantillaRepository.GetPlantilla(plantillaId) != null? true : false;
        }

        private TaakPlantilla GetPlantilla(int plantillaId)
        {
            return _plantillaRepository.GetPlantilla(plantillaId);
        }

    }
}
