using GoFood.Application.Dtos;
using GoFood.Application.InputModels;

namespace GoFood.Application.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<ResultPlacesDto>> GetLocationAsync(UserInputModel userInputModel);
    }
}