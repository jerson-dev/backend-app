using Application.Interfaces;
using Application.Requests.Anuncio;
using Application.Responses;
using Application.Responses.Anuncio;
using Application.Services;
using Application.Utilities.Exceptions;
using Domain.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : Controller
    {
        private readonly IAnuncioService _anuncioService;


        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        // GET
        [HttpGet("GetAnuncios")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult Index()
        {
            try
            {
                var anuncios = _anuncioService.GetAnuncios();

                var response = _anuncioService.BuildAnuncioResponse(anuncios);

                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }

        }

        //GetAnunciosByClienteId
        [HttpGet("GetAnunciosByClienteId/{clienteId}")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult GetAnunciosByClienteId(int clienteId)
        {
            try
            {
                var anuncios = _anuncioService.GetAnunciosByClienteId(clienteId);
                var response = _anuncioService.BuildAnuncioResponse(anuncios);
                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        //GetAnunciosByBusqueda
        [HttpGet("GetAnunciosByBusqueda/{texto}")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult GetAnunciosByBusqueda(string texto)
        {
            try
            {
                var anuncios = _anuncioService.GetAnuncioByBusqueda(texto);
                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.OK, "Success", anuncios);
                return Ok(responseDto);
            }
            catch (ValidationException ex) when (ex.Message == Exceptions.MessagesExceptions.NoAnunciosFound)
            {
                var responseDto = new ResponseDto<List<AnuncioResponse>>(HttpStatusCode.NotFound, ex.Message, null);
                return BadRequest(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        // POST
        [HttpPost("RegisterAnuncio")]
        public IActionResult RegisterAnuncio(RegisterAnuncioRequest anuncioRequest)
        {
            try
            {
                _anuncioService.CreateAnuncio(anuncioRequest);
                var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "success", null);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
