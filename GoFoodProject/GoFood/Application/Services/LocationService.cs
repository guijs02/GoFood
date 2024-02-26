using GoFood.Application.Services.Interfaces;
using GoFood.Client.Domain.Model;
using GoFood.Domain.Exceptions;
using GoFood.Domain.Extension;
using GoFood.Domain.Google.GeoCode;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Services
{
    public class LocationService : ILocationService
    {
        public readonly HttpClient _http;
        public readonly IPlacesService _placesService;
        public LocationService(IPlacesService placesService)
        {
            _http = new HttpClient { BaseAddress = new Uri("https://localhost:7164") };
            _placesService = placesService;
        }

        public async Task<Root> GetLocationAsync(UserInputModel userInputModel)
        {
            try
            {
                string endereco = userInputModel.Endereco.Trim();

                var response = await _http.GetAsync($"{GeoCodeAPI.EndPoint}/{endereco.Trim()}");

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
                    radius = userInputModel.Radius.ToString()
                };

                var dadosPlace = await _placesService.GetPlacesAroundAsync(placesRequest);

                await ObterPhotosAPI(dadosPlace);

                return dadosPlace;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task ObterPhotosAPI(Root dadosPlace)
        {
            List<string> listPhotoRef = new();

            var photoTasks = await Task.Factory.StartNew(async () =>
            {
                foreach (var place in dadosPlace.results)
                {
                    if (place.photos == null)
                        continue;

                    foreach (var photo in place.photos)
                    {
                        listPhotoRef.Add(photo.photo_reference);
                    }
                    foreach (var photoRef in listPhotoRef)
                    {
                        place.PhotoReference = photoRef;

                        var content = await _http.GetAsync($"api/Photo/{photoRef}");

                        var photo = await content.Content.ReadAsStringAsync();

                        place.DictionaryFotos.Add(photoRef, photo);

                    }
                }
            });
            await Task.WhenAll(photoTasks);
        }

    }
}
