using Application.Interfaces;
using Application.Responses;
using Application.Responses.Dominio;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominioController : Controller
    {
        private readonly IDominioService _dominioService;

        public DominioController(IDominioService dominioService)
        {
            _dominioService = dominioService;
        }

        // GET: DominioController
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var dominios =  _dominioService.GetDominios();

                var response = BuildDominioResponse(dominios);

                var responseDto = new ResponseDto<List<DominioResponse>>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<DominioResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        private List<DominioResponse> BuildDominioResponse(IEnumerable<TaakDominio> dominios)
        {
            return dominios.Select(dominio => new DominioResponse
            {
                IdCasaEstudio = dominio.CasaEstudio.CasaEstudioId,
                CasaEstudio = dominio.CasaEstudio.CasaEstudio,
                Dominio = dominio.Dominio.ToString()
            }).ToList();
        }

        //private IActionResult resultResponse(object data, int statusCode, string message)
        //{
        //    var customResponse = new ResponseDto<object>(statusCode, message, data);
        //    if (statusCode == 200)
        //    {
        //        return Ok(customResponse);
        //    }
        //    else if (statusCode == 400)
        //    {
        //        return BadRequest(customResponse);
        //    }
        //    else if (statusCode == 500)
        //    {
        //        return StatusCode(500, customResponse);
        //    }
        //    else
        //    {
        //        // En caso de otro código de estado, devolver un error genérico
        //        return StatusCode(500, new ResponseDto<object>(500, "Internal server error", null));
        //    }
        //}
    }
}
