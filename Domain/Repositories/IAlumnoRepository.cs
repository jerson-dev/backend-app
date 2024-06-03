using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAlumnoRepository
    {
        public void CreateAlumno(TaakAlumno alumno);
        public List<TaakAlumno> GetAll();
        public bool UpdateDatosAlumnoDireccion(TaakAlumno alumno);
        public bool UpdateDatosAlumnoContacto(TaakAlumno alumno);
        public bool UpdateDatosAlumnoAcademico(TaakAlumno alumno);
        public void UpdateDatosAlumnoBancarios(TaakAlumno alumno);
        List<TaakAlumno> GetAlumnosByUserId(int userId);
        public TaakAlumno? GetById(int id);
    }
}
