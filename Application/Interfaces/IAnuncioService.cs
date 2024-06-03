using Application.Requests.Anuncio;
using Application.Responses.Anuncio;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IAnuncioService
    {
        public List<TaakAnuncio> GetAnuncios();
        public void CreateAnuncio(RegisterAnuncioRequest newAnuncio);
        List<TaakAnuncio> GetAnunciosByClienteId(int clienteId);
        List<AnuncioResponse> BuildAnuncioResponse(IEnumerable<TaakAnuncio> anuncios);
        List<AnuncioResponse> GetAnuncioByBusqueda(string texto);
    }
}
