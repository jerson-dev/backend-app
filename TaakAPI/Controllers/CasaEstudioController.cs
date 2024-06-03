using Application.Interfaces;
using Application.Responses.Carrera;
using Application.Responses;
using Application.Responses.CasaEstudio;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasaEstudioController : Controller
    {
        private readonly ICasaEstudioService _casaEstudioService;

        public CasaEstudioController(ICasaEstudioService casaEstudioService)
        {
            _casaEstudioService = casaEstudioService;
        }

        // GET: CasaEstudioController
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var casaEstudios = _casaEstudioService.GetCasaEstudio();

                var response = casaEstudios.Select(casaEstudio => new CasaEstudioResponse
                {
                    Id = casaEstudio.CasaEstudioId,
                    CasaEstudio = casaEstudio.CasaEstudio
                }).ToList();

                var responseDto = new ResponseDto<List<CasaEstudioResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<CasaEstudioResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
