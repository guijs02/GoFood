using GoFood.Application.API_s;
using GoFood.Application.Dtos;
using GoFood.Application.InputModels;
using GoFood.Application.Services.Interfaces;
using GoFood.Domain.Exceptions;
using GoFood.Domain.Extension;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Services
{
    public class LocationService : BaseService, ILocationService
    {
        public readonly HttpClient _http;
        public readonly IPlacesService _placesService;
        public LocationService(IPlacesService placesService)
        {
            _http = ConfigureHttpUrl();
            _placesService = placesService;
        }

        public async Task<List<ResultPlacesDto>> GetLocationAsync(UserInputModel userInputModel)
        {
            try
            {
                var request = string.Format(GeoCodeAPI.EndPoint, userInputModel.Endereco);

                var response = await _http.GetAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException();
                }

                var rootObject = await response.ReadJsonAsObject<RootObject>();

                var location = rootObject.results.First().geometry.location;

                PlacesRequest placesRequest = new()
                {
                    lat = location.lat,
                    lng = location.lng,
                    radius = userInputModel.Radius.ToString(),
                    filtroPlaces = new FiltroPlaces
                    {
                        isOpen = userInputModel.IsOpen,
                        qtdRating = userInputModel.QtdAvaliacoes
                    }
                };

                var dadosPlace = await _placesService.GetPlacesAroundAsync(placesRequest);

                await GetPhotosAsync(dadosPlace);

                return dadosPlace;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task GetPhotosAsync(List<ResultPlacesDto> dadosPlace)
        {
            var photoTasks = await Task.Factory.StartNew(
            async () =>
            await SendRequestPhotoAPI(dadosPlace)
            );
            await photoTasks;
        }
        private async Task SendRequestPhotoAPI(List<ResultPlacesDto> resultPlacesDto)
        {
            foreach (var place in resultPlacesDto)
            {
                if (place.PhotoReference is null) continue;

                var request = string.Format(PhotosAPI.Endpoint, place.PhotoReference);

                var content = await _http.GetAsync(request);

                var urlPhoto = await content.Content.ReadAsStringAsync();

                place.DictionaryFotos.Add(place.PhotoReference, urlPhoto);
            }
        }

    }
}
