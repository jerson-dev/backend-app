using Domain.Models;

namespace Domain.Repositories
{
    public interface IAnuncioRepository
    {
        List<TaakAnuncio> GetAnuncio();
        public void CreateAnuncio(TaakAnuncio anuncio);
        List<TaakAnuncio> GetAnunciosByClienteId(int clienteId); // Nuevo método que retorne los anuncios asociados a cada cliente
        List<TaakAnuncio> GetAnuncioByBusqueda(string texto);
    }
}
