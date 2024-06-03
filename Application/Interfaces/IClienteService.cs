using Application.Requests;
using Application.Requests.Admin;
using Application.Requests.Alumno;
using Application.Requests.Cliente;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        public TaakCliente CreateKam(RegisterClienteRequest cliente);

        public bool IsExistRut(string rut);

        public bool IsExistEmail(string email);
        public List<TaakCliente> GetCliente();
        public List<TaakCliente> GetAll();

        public TaakCliente UpdateCliente(UpdateClienteRequest cliente);

        public Task SendTokenMailClienteAsync(RegisterClienteRequest register, string passTCNohash, string titleMsn);

    }
}
