using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class RutUtils
    {
        public static string CleanUserRut(this string rut)
        {
            // Eliminar puntos y guiones del Rut
            return rut.Replace(".", "").Replace("-", "");
        }

        public static string CleanAlumnoRut(this string rut)
        {
            // Eliminar solo los puntos del Rut y mantener el guión
            return rut.Replace(".", "");
        }
    }
}
