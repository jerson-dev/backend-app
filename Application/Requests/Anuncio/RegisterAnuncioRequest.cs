
namespace Application.Requests.Anuncio
{
    public class RegisterAnuncioRequest
    {
        public string? DiaServicio { get; set; }

        public DateTime? JornadaInicio { get; set; }

        public DateTime? JornadaTermino { get; set; }

        public decimal? MontoPagar { get; set; }

        public string? Descripcion { get; set; }

        public string? Region { get; set; }

        public string? Ciudad { get; set; }

        public string? Comuna { get; set; }

        public string? Direccion { get; set; }

        public string? Numero { get; set; }

        public string? NumeroDpto { get; set; }

        public string? Longitud { get; set; }

        public string? Latitud { get; set; }

        public int PlantillaId { get; set; }

    }
}
