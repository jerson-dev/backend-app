using Application.Interfaces;
using Application.Responses;
using Application.Responses.Carrera;
using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : Controller
    {
        private readonly ICarreraService _carreraService;

        public CarreraController(ICarreraService carreraService)
        {
            _carreraService = carreraService;
        }

        // GET: DominioController
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var carreras = _carreraService.GetCarrera();

                var response = carreras.Select(carrera => new CarreraResponse
                {

                    Id = carrera.CarreraId,
                    Carrera = carrera.Carrera

                }).ToList();

                var responseDto = new ResponseDto<List<CarreraResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<CarreraResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
            
        }
    }
}
