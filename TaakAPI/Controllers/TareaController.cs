using Application.Interfaces;
using Application.Responses;
using Application.Responses.Tarea;
using Application.Services;

using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : Controller
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService areaService)
        {
            _tareaService = areaService;
        }

        [HttpGet("GetTareaByTipoTareaId/{tipoTareaId}")]
        public IActionResult GetTareaByTipoTareaId(int tipoTareaId)
        {
            var response = _tareaService.GetTareaByTipoTareaId(tipoTareaId);

            return this.CreateResponse(HttpStatusCode.OK, "Success", response); ;
        }

        [HttpGet("GetDetalleTareaByTareaId/{TareaId}")]
        public IActionResult GetDetalleTareaByTareaId(int TareaId)
        {
            //obtener detalle tarea
            //realizar switch por el tipo de id de la tarea
            var response = _tareaService.GetTareaById(TareaId);

            return this.CreateResponse(HttpStatusCode.OK, "Success", response);
        }

        [HttpPost("AddTareaEnrolamiento")]
        public IActionResult AddTareaEnrolamiento(IFormFile file, [FromQuery] int usuarioId, [FromQuery] int tipoEnrolamiento)
        {
            try
            {
                //hacer que retorne el tareaId
                var x = _tareaService.AddTareaEnrolamiento(tipoEnrolamiento, usuarioId);

                //Agregar metodo para subir archivo, recibe el tareaId para nombrar al archivo

                return Ok(new { message = "Archivo cargado con éxito." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
