using Application.Interfaces;
using Application.Responses;
using Application.Responses.Dominio;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("GetEmpresas")]
        public IActionResult GetAll()
        {
            try
            {
                var empresas = _empresaService.GetEmpresas();

                var response = empresas.Select(empresas => new EmpresaResponse
                {
                    Id = empresas.EmpresaId,
                    RazonSocial = empresas.RazonSocial,
               
                }).ToList();

                var responseDto = new ResponseDto<List<EmpresaResponse>>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<EmpresaResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
