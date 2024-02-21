namespace GoFood.Application.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Root> GetLocationAsync(string endereco);
    }
}