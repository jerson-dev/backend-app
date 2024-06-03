using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Tarea
{
    public class TareaResponse
    {
        public int TareaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaGestion { get; set; }

        public int? UsuarioIngresoId { get; set; }

        public string? NombreIngreso { get; set; }

        public string? RutIngreso { get; set; }

        public int? UsuarioGestionId { get; set; }

        public int? TipoTareaId { get; set; }

        public string? TipoTarea { get; set; }
        
        public int? EstadoTareaId { get; set; }

        public string? Estado { get; set; }



    }
}
