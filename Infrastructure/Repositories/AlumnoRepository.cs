using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly ApplicationDbContext _context;

        public AlumnoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateAlumno(TaakAlumno alumno)
        {
            _context.TaakAlumno.Add(alumno);
            _context.SaveChanges();
        }

        public List<TaakAlumno> GetAll()
        {
            return _context.TaakAlumno.ToList();
        }

        public bool UpdateDatosAlumnoDireccion(TaakAlumno alumno)
        {
            _context.TaakAlumno.Update(alumno);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateDatosAlumnoContacto(TaakAlumno alumno)
        {
            _context.TaakAlumno.Update(alumno);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateDatosAlumnoAcademico(TaakAlumno alumno)
        {
            var existingAlumno = _context.TaakAlumno
                .Include(a => a.Carrera)
                .Include(a => a.CasaEstudio)
                .FirstOrDefault(a => a.AlumnoId == alumno.AlumnoId);

            if (existingAlumno == null)
            {
                return false;
            }

            // Actualiza las propiedades 
            existingAlumno.CarreraId = alumno.CarreraId;
            existingAlumno.CasaEstudioId = alumno.CasaEstudioId;
            existingAlumno.Carrera = alumno.Carrera;
            existingAlumno.CasaEstudio = alumno.CasaEstudio;

            _context.SaveChanges();
            return true;
        }
        public void UpdateDatosAlumnoBancarios(TaakAlumno alumno)
        {
            _context.TaakAlumno.Update(alumno);
            _context.SaveChanges();
        }

        public List<TaakAlumno> GetAlumnosByUserId(int userId)
        {
            return _context.TaakAlumno
                .Where(a => a.UsuarioId == userId)
                .ToList();
        }

        public TaakAlumno? GetById(int id)
        {
            return _context.TaakAlumno
                .Where(u => u.UsuarioId == id).FirstOrDefault();
        }
    }
}
