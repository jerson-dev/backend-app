using Application.Interfaces;
using Application.Requests.Alumno;
using Application.Responses;
using Application.Responses.Admin;
using Application.Responses.Alumno;
using Application.Responses.Anuncio;
using Application.Services;
using Domain.Models;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Application.Utilities.Exceptions.Exceptions;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IAlumnoService _alumnoService;

        public AlumnoController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        //GetAnunciosByClienteId
        [HttpGet("GetAlumnosByUserId/{userId}")]
        //[Authorize(Roles = "Administrador, Cliente")]
        public IActionResult GetAlumnosByUserId(int userId)
        {
            try
            {
                var alumnos = _alumnoService.GetAlumnosByUserId(userId);
                var response = _alumnoService.BuildAlumnoResponse(alumnos);
                var responseDto = new ResponseDto<List<AlumnoResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AlumnoResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpPost("RegisterAlumno")]
        public async Task<IActionResult> CreateAlumno([FromBody] RegisterAlumnoRequest request)
        {
                AlumnoResponse alumnoResponse = await _alumnoService.CreateAlumno(request);
                return this.CreateResponse(HttpStatusCode.OK, "Success", alumnoResponse);
        }

        [HttpGet("ExistRutAlumno")]
        public IActionResult ExistRutAlumno(string rut)
        {
            try
            {
                var response = new
                {
                    isExist = _alumnoService.IsExistRut(rut)
                };
                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("ExistEmailAlumno")]
        public IActionResult ExistEmailAlumno(string email)
        {
            try
            {
                var response = new
                {
                    isExist = _alumnoService.IsExistEmail(email)
                };
                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            var request = HttpContext.Request;

            _alumnoService.SendWelcomeMail();
            return Ok();
        }

        [HttpPut("UpdateDatosAlumnoDireccion/{id}")]
        public IActionResult UpdateDatosAlumnoDireccion(int id, [FromBody] UpdateAlumnoRequestDireccion alumnoRequest)
        {
            try
            {
                var result = _alumnoService.UpdateDatosAlumnoDireccion(id, alumnoRequest);
                if (result)
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "Registro actualizado", true);
                    return Ok(responseDto);
                }
                else 
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, "Error al actualizar el registro", false);
                    return BadRequest(responseDto);
                }
            }
            catch (ValidationException ex) when (ex.Message == MessagesExceptions.IdDoesntExist)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.NotFound, ex.Message, false);
                return NotFound(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpPut("UpdateDatosAlumnoContacto/{id}")]
        public IActionResult UpdateDatosAlumnoContacto(int id, [FromBody] UpdateAlumnoRequestContacto alumnoRequest)
        {
            try
            {
                var result = _alumnoService.UpdateDatosAlumnoContacto(id, alumnoRequest);
                if (result)
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "Registro actualizado", true);
                    return Ok(responseDto);
                }
                else
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, "Error al actualizar el registro", false);
                    return BadRequest(responseDto);
                }
            }
            catch (ValidationException ex) when (ex.Message == MessagesExceptions.IdDoesntExist)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.NotFound, ex.Message, false);
                return NotFound(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpPut("UpdateDatosAlumnoAcademico/{id}")]
        public IActionResult UpdateDatosAlumnoAcademico(int id, [FromBody] UpdateAlumnoRequestAcademico alumnoRequest)
        {
            try
            {
                var result = _alumnoService.UpdateDatosAlumnoAcademico(id, alumnoRequest);
                if (result)
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "Registro actualizado", true);
                    return Ok(responseDto);
                }
                else
                {
                    var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, "Error al actualizar el registro", false);
                    return BadRequest(responseDto);
                }
            }
            catch (ValidationException ex) when (ex.Message == MessagesExceptions.IdDoesntExist)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.NotFound, ex.Message, false);
                return NotFound(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }
    }
}
