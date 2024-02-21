using SistemaRecomendacaoRestuaruantes.Domain.Dtos;

namespace SistemaRecomendacaoRestuaruantes.Application.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Root> GetLocationAsync(string endereco);
    }
}