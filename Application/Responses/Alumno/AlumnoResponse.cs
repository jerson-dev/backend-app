using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Alumno
{
    public class AlumnoResponse
    {
        public int AlumnoId { get; set; }

        public string PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Rut { get; set; }

        public string Region { get; set; }

        public string Ciudad { get; set; }

        public string Comuna { get; set; }

        public string Direccion { get; set; }

        public string Numero { get; set; }

        public string? NumeroDpto { get; set; }

        public string Longitud { get; set; }

        public string Latitud { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string AnioCurso { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int CasaEstudioId { get; set; }

        public int CarreraId { get; set; }

        public int? DatoBancarioId { get; set; }

        public int UsuarioId { get; set; }

        public int ProspectoId { get; set; }


    }
}
