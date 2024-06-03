using Application.Interfaces;
using Application.Requests.Admin;
using Application.Responses;
using Application.Responses.Admin;
using Application.Responses.Motivo;
using Application.Responses.Prospecto;
using Application.Services;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin([FromBody]RegisterAdminRequest request)
        {
            _adminService.CreateAdmin(request);
            return this.CreateResponse(HttpStatusCode.Created, "Success", null);

            //try
            //{
            //    var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "success", null);
            //    return Ok(responseDto);
            //}
            //catch (Exception ex)
            //{
            //    var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
            //    return BadRequest(responseDto);
            //}
        }

        [HttpGet("ExistRutAdmin")]
        public IActionResult ExistRutAdmin(string rut)
        {
            try
            {
                var response = new
                {
                    isExist = _adminService.IsExistRut(rut)
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("ExistEmailAdmin")]
        public IActionResult ExistEmailAdmin(string email)
        {
            try
            {
                var response = new
                {
                    isExist = _adminService.IsExistEmail(email)
                };
                var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        // GET: AdminController
        [HttpGet("GetAllAdmins")]
        public IActionResult Index()
        {
            try
            { 
                var administrador = _adminService.GetAdmin();

                var response = administrador.Select(administrador => new AdminResponse
                {
                    AdminId = administrador.AdministradorId,
                    Nombre = administrador.PrimerNombre + " " + administrador.SegundoNombre,

                    Apellido = administrador.ApellidoPaterno,
                    SegundoApellido = administrador.ApellidoMaterno,
                    Rut = administrador.Rut,
                    KamId = administrador.lstKam?.FirstOrDefault()?.Id
                }).ToList();

                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.OK, "Success", response);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<List<AdminResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }


    }
}
