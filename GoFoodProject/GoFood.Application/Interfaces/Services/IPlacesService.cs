using GoFood.Application.Dtos;
using GoFood.Application.InputModels;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Services.Interfaces
{
    public interface IPlacesService
    {
        Task<List<ResultPlacesDto>> GetPlacesAroundAsync(UserInputModel userInputModel, Location location);
        Task<IEnumerable<string>> GetPlacesByAutoComplete(string input);
    }
}