using Application.Interfaces;
using Application.Requests;
using Application.Responses;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenCorreoController : Controller
    {
        private readonly ITokenCorreoService _tokenCorreoService;

        public TokenCorreoController(ITokenCorreoService tokenCorreoService)
        {
            _tokenCorreoService = tokenCorreoService;
        }

        [HttpPost("RegisterTokenCorreo")]
        public async Task<IActionResult> RegiterTokenCorreoAsync(RegisterTokenCorreoRequest request)
        {
            try
            {
                await _tokenCorreoService.CreateTokenCorreoAsync(request).ConfigureAwait(false);

                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "success", null);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("ValidateToken")]
        public IActionResult ValidateTokenEP(string email, string token)
        {
            try
            {
                var response = new
                {
                    isValid = _tokenCorreoService.IsExistToken(email, token)
                };

                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "success", response);

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
