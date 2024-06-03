using Application.Interfaces;
using Application.Responses.Carrera;
using Application.Responses;
using Application.Responses.Tipo_Plantilla;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPlantillaController : Controller
    {
        private readonly ITipoPlantillaService _tipoPlantillaService;

        public TipoPlantillaController(ITipoPlantillaService tipoPlantillaService)
        {
            _tipoPlantillaService = tipoPlantillaService;
        }

        [HttpGet("GetAllTipoPlantilla")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult Index()
        {
            try
            {
                var tipoPlantillas = _tipoPlantillaService.GetAllTipoPlantilla();

                var response = tipoPlantillas.Select(tipoPlantillas => new TipoPlantillaResponse
                {
                    TipoPlantillaId = tipoPlantillas.TipoPlantillaId,
                    TipoPlantilla = tipoPlantillas.TipoPlantilla

                }).ToList();

                var responseDto = new ResponseDto<List<TipoPlantillaResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<TipoPlantillaResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
