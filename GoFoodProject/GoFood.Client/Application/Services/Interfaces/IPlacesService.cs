namespace SistemaRecomendacaoRestuaruantes.Application.Services.Interfaces
{
    public interface IPlacesService
    {
        Task<Root> GetPlacesAroundAsync(Location location);
    }
}