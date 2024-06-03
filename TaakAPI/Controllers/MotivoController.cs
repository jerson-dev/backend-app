using Application.Interfaces;
using Application.Responses;
using Application.Responses.Motivo;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoController : Controller
    {
        private readonly IMotivoService _motivoService;

        public MotivoController(IMotivoService motivoService)
        {
            _motivoService = motivoService;
        }

        // GET: DominioController
        [HttpGet("GetAllMotivos")]
        public IActionResult Index()
        {
            try
            {
                var motivos =  _motivoService.GetAllMotivos();

                var response = BuildMotivoResponse(motivos);

                var responseDto = new ResponseDto<List<MotivoResponse>>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<MotivoResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }

        }

        private List<MotivoResponse> BuildMotivoResponse(IEnumerable<TaakSolicitudMotivo> motivos)
        {
            return motivos.Select(motivo => new MotivoResponse
            {
                MotivoId = motivo.MotivoId,
                Nombre = motivo.Nombre.ToString(),
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
