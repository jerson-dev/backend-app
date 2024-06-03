using Application.Interfaces;
using Application.Requests.Plantilla;
using Application.Responses;
using Application.Responses.Plantilla;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantillaController : Controller
    {
        private readonly IPlantillaService _plantillaService;

        public PlantillaController(IPlantillaService plantillaService)
        {
            _plantillaService = plantillaService;
        }

        [HttpPost("RegisterPlantilla")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult RegisterPlantilla(RegisterPlantillaRequest request)
        {
            try
            {
                _plantillaService.CreatePlantilla(request);
                var responseDto = new ResponseDto<Object>(HttpStatusCode.Created, "success", null);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("GetAllPlantillas")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult Index()
        {
            try
            {
                var plantillas = _plantillaService.GetAllPlantillas();

                var response = plantillas.Select(plantillas => new PlantillaResponse
                {
                    PlantillaId = plantillas.PlantillaId,
                    Titulo = plantillas.Titulo,
                    Descipcion = plantillas.Descipcion,
                    Requisitos = plantillas.Requisitos,
                    ClienteId = plantillas.ClienteId,
                    TipoPlantillaId = plantillas.TipoPlantillaId,
                    TipoPlantilla = plantillas.TipoPlantilla!.TipoPlantilla,
                    KamId = plantillas.KamId,
                }).ToList();

                var responseDto = new ResponseDto<List<PlantillaResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<PlantillaResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("GetPlantillaByClienteId")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult GetPlantillaByClienteId(int clienteId)
        {
            try
            {
                var response = _plantillaService.GetPlantillaByClienteId(clienteId);
                var responseDto = new ResponseDto<List<PlantillaResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<PlantillaResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }

        }

        [HttpPut("UpdatePlantilla/{id}")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult UpdatePlantilla(int id, [FromBody] UpdatePlantillaRequest request)
        {
            try
            {
                bool result = _plantillaService.UpdatePlantilla(id, request);

                if (result)
                {
                    return Ok(new ResponseDto<bool>(HttpStatusCode.OK, "Plantilla actualizada exitosamente",true));
                }
                else
                {
                    return BadRequest(new ResponseDto<bool>(HttpStatusCode.BadRequest,"Error al actualizar la plantilla", false));
                }
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ResponseDto<bool>(HttpStatusCode.BadRequest, ex.Message, false));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new ResponseDto(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

    }
}
