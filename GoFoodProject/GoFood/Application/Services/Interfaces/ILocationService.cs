using GoFood.Client.Domain.Model;

namespace GoFood.Application.Services.Interfaces
{
    public interface ILocationService
    {
        Task<Root> GetLocationAsync(UserInputModel userInputModel);
    }
}