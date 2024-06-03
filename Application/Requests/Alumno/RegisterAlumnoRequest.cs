namespace Application.Requests.Alumno
{
    public class RegisterAlumnoRequest
    {
        public string? Nombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? Apellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Rut { get; set; }
        public string? Region { get; set; }
        public string? Ciudad { get; set; }
        public string? Comuna { get; set; }
        public string? Direccion { get; set; }
        public string? Numero { get; set; }
        public string? NroDpto { get; set; }
        public string? Longitud { get; set; }
        public string? Latitud { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasenia { get; set; }
        public string? AnioCurso { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int CasaEstudioId { get; set; }
        public int CarreraId { get; set; }
        public int ProspectoId { get; set; }
    }
}
