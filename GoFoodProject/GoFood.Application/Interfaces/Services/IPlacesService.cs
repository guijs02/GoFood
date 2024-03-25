using GoFood.Application.Dtos;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Services.Interfaces
{
    public interface IPlacesService
    {
        Task<List<ResultPlacesDto>> GetPlacesAroundAsync(PlacesRequest places);
        Task<IEnumerable<string>> GetPlacesByAutoComplete(string input);
    }
}