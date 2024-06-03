using Application.Interfaces.Utilities;
using Application.Requests.Auth;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            try
            {
                var authResponse = _authService.Authenticate(request);
                var response = new
                {
                    token = authResponse.Item1,
                    roleId = authResponse.Item2,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("AuthenticateAdmin")]
        public IActionResult AuthenticateAdmin(AuthenticateRequest request)
        {
            try
            {
                var tokenResponse = _authService.AuthenticateAdmin(request);
                var response = new
                {
                    token = tokenResponse,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("AuthenticateCliente")]
        public IActionResult AuthenticateCliente(AuthenticateRequest request)
        {
            try
            {
                var tokenResponse = _authService.AuthenticateCliente(request);
                var response = new
                {
                    token = tokenResponse,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("AuthenticateAlumno")]
        public IActionResult AuthenticateAlumno(AuthenticateRequest request)
        {
            try
            {
                var tokenResponse = _authService.AuthenticateAlumno(request);
                var response = new
                {
                    token = tokenResponse,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("ValidateTokenAdmin")]
        public IActionResult ValidateTokenAdmin(ValidateTokenRequest request)
        {
            try
            {
                var isValid = _authService.ValidateAuthenticate(request.token, 1);
                var response = new
                {
                    isValid,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("ValidateTokenCliente")]
        public IActionResult ValidateTokenCliente(ValidateTokenRequest request)
        {
            try
            {
                var isValid = _authService.ValidateAuthenticate(request.token, 2);
                var response = new
                {
                    isValid,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
        [HttpPost("ValidateTokenAlumno")]
        public IActionResult ValidateTokenAlumno(ValidateTokenRequest request)
        {
            try
            {
                var isValid = _authService.ValidateAuthenticate(request.token, 3);
                var response = new
                {
                    isValid,
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.OK, "Success", response);

                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<string>(HttpStatusCode.BadRequest, ex.Message, null));
            }
        }
    }
}
