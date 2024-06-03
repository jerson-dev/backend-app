using Application.Interfaces;
using Application.Responses;
using Application.Responses.Prospecto;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProspectoController : Controller
    {
        private readonly IProspectoService _prospectoService;

        public ProspectoController(IProspectoService prospectoService)
        {
            _prospectoService = prospectoService;
        }

        // GET: ProspectoController
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var prospecto = _prospectoService.GetProspecto();

                var response = prospecto.Select(prospecto => new ProspectoResponse
                {
                    IdProspecto = prospecto.ProspectoId,
                    Prospecto = prospecto.Nombre
                }).ToList();

                var responseDto = new ResponseDto<List<ProspectoResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<ProspectoResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
