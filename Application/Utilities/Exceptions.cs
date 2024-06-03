using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.Exceptions
{
    public class Exceptions
    {
        public class MessagesExceptions
        {
            public static string MotivoNotFoundException = "No hay motivo disponible para crear el contacto.";
            //public static string AdminNotFoundException = "No hay administrador de contacto disponible para recibir el correo.";
            public static string FieldsRequired = "Todos los campos son obligatorios.";
            public static string RutsExist = "Este rut ya se encuentra registrado";
            public static string EmailsExist = "Este email ya se encuentra registrado";
            public static string DominioNotPermitted = "El dominio del correo electrónico no está permitido";
            public static string IdAdminNotExist = "El AdministradorId proporcionado no existe.";
            public static string IdEmpresaNotExist = "El EmpresaId proporcionado no existe.";
            public static string IdPlantillaNotExist = "El PlantillaId proporcionado no existe.";
            public static string IdAdminIsNull = "El ID del administrador es nulo.";
            public static string IdDoesntExist = "El Id ingresado no existe.";
            public static string IdKamNotExist = "El KamId proporcionado no existe.";
            public static string IdTipoPlantillaNotExist = "El TipoPlantillaId proporcionado no existe.";
            public static string IdClienteNotExist = "El ClienteId proporcionado no existe.";
            public static string IdUserNotExist = "El UserId proporcionado no existe.";
            public static string NoAnunciosFound = "No se encontraron anuncios con el texto proporcionado.";
        }

    }
}
