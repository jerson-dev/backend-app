using Application.Interfaces;
using Application.Responses;
using Application.Requests.Cliente;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Application.Responses.Cliente;
using Application.Responses.Admin;

namespace TaakAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost("RegisterCliente")]        
        public IActionResult RegisterCliente(RegisterClienteRequest request)
        {
            try
            {
                _clienteService.CreateKam(request);
                var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "success", null);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto<object>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpGet("ExistRutCliente")]
        public IActionResult ExistRutCliente(string rut)
        {
            try
            {
                var response = new
                {
                    isExist = _clienteService.IsExistRut(rut)
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

        [HttpGet("ExistEmailCliente")]
        public IActionResult ExistEmailCliente(string email)
        {
            try
            {
                var response = new
                {
                    isExist = _clienteService.IsExistEmail(email)
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
       
        [HttpGet("GetCLientes")]
        public IActionResult ListCLientes()
        {
            try
            {
                var clientes = _clienteService.GetAll();

                var response = clientes.Select(clientes => new ClienteResponse
                {
                    ClienteId = clientes.ClienteId,
                    RazonSocial = clientes.Nombre,
                    Descipcion = clientes.Descipcion,
                    Rut = clientes.Rut,
                    Email = clientes.Email,
                    Telefono = clientes.Telefono,
                    Celular = clientes.Celular,
                    EmpresaId = clientes.EmpresaId,
                    Empresa = clientes.Empresa.RazonSocial,
                    lstAdminResponse = clientes.lstKam!.Select(admin => new AdminResponse
                    {
                        AdminId = admin.AdministradorId,
                        KamId = admin.Id,
                        Nombre = admin.Administrador.PrimerNombre,
                        Apellido = admin.Administrador.ApellidoPaterno,
                        SegundoApellido = admin.Administrador.ApellidoMaterno,
                        Rut = admin.Administrador.Rut
                    }).ToList()
                });

                //var responseDto = new ResponseDto<List<RegisterClienteRequest>>(HttpStatusCode.OK, "success", response);

                var responseDto = new ResponseDto<List<ClienteResponse>>(HttpStatusCode.OK, "success", response);
                return Ok(responseDto);
            }
            catch (Exception ex) 
            { 
                var responseDto = new ResponseDto<List<ClienteResponse>>(HttpStatusCode.BadRequest, ex.Message, null);
                return BadRequest(responseDto);
            }
        }

        [HttpPut("UpdateCliente")]
        public IActionResult UpdateCliente(UpdateClienteRequest request)
        {
            try
            {
                var objectCliente = _clienteService.UpdateCliente(request);
                //_clienteService.UpdateCliente(request);
                var responseDto = new ResponseDto<object>(HttpStatusCode.Created, "Registro actializado", null);
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
