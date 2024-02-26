using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Services.Interfaces
{
    public interface IPlacesService
    {
        Task<Root> GetPlacesAroundAsync(PlacesRequest places);
    }
}