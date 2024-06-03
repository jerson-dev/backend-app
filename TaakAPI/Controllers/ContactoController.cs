using Application.Interfaces;
using Application.Requests.Admin;
using Application.Requests.Contacto;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : Controller
    {
        private readonly IContactoService _contactoService;
        public ContactoController(IContactoService contactoService)
        {
            _contactoService = contactoService;
        }

        [HttpPost("RegisterContacto")]
        public IActionResult RegisterContacto(RegisterContactoRequest contactoRequest)
        {
            try
            {
                _contactoService.CreateContacto(contactoRequest);
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
