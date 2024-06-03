using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Alumno
{
    public class UpdateAlumnoRequestAcademico
    {
        public int CarreraId { get; set; }
        public string Carrera { get; set; }
        public int CasaEstudioId { get; set; }
        public string CasaEstudio { get; set; }
    }
}
