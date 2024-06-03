using Application.Requests.Alumno;
using Application.Responses.Alumno;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAlumnoService
    {
        public Task<AlumnoResponse> CreateAlumno(RegisterAlumnoRequest alumno);
        public AlumnoResponse ConvertToAlumnoResponse(TaakAlumno alumno); 
        public bool IsExistRut(string rut);
        public bool IsExistEmail(string email);

        public bool UpdateDatosAlumnoDireccion(int id, UpdateAlumnoRequestDireccion alumnoRequest);
        public bool UpdateDatosAlumnoContacto(int id, UpdateAlumnoRequestContacto alumnoRequest);
        public bool UpdateDatosAlumnoAcademico(int id, UpdateAlumnoRequestAcademico alumnoRequest);
        //public TaakAlumno UpdateDatosAlumnoBancarios(UpdateAlumnoRequest alumno);
        public void SendWelcomeMail();
        public List<AlumnoResponse> BuildAlumnoResponse(IEnumerable<TaakAlumno> alumnos);
        List<TaakAlumno> GetAlumnosByUserId(int userId);

    }
}
