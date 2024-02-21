using SistemaRecomendacaoRestuaruantes.Application.Services.Interfaces;
using SistemaRecomendacaoRestuaruantes.Domain.Exceptions;
using SistemaRecomendacaoRestuaruantes.Domain.Extension;
using SistemaRecomendacaoRestuaruantes.Domain.Google.GeoCode;

namespace SistemaRecomendacaoRestuaruantes.Application.Services
{
    public class LocationService : ILocationService
    {
        public readonly HttpClient _http;
        public readonly IConfiguration _configuration;
        public readonly IPlacesService _placesService;
        public LocationService(HttpClient http, IConfiguration configuration, IPlacesService placesService)
        {
            _http = new HttpClient { BaseAddress = new Uri("https://localhost:7164") };
            _configuration = configuration;
            _placesService = placesService;
        }

        public async Task<Root> GetLocationAsync(string endereco)
        {
            try
            {
                var key = "AIzaSyDcsebA5tahocCK-Bc284XpbRTCyWylA6o";

                var response = await _http.GetAsync($"{GeoCodeAPI.EndPoint}/{endereco.Trim()}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException();
                }

                var rootObject = await response.ReadJsonAsObject<RootObject>();

                if (rootObject is null)
                {
                    throw new DeserializeToObjectException();
                }

                var location = rootObject.results.First().geometry.location;

                var dadosPlace = await _placesService.GetPlacesAroundAsync(location);

                List<string> listPhotoRef = new();

                string baseUrl = "https://maps.googleapis.com/maps/api/place/photo?";

                int maxWidth = 400;
                int minWidth = 130;

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
                            var photoUrl = $"{baseUrl}maxwidth={maxWidth}&minwidth={minWidth}&photoreference={photoRef}&key={key}";
                            place.DictionaryFotos.Add(photoRef, photoUrl);

                        }
                    }
                });

                await Task.WhenAll(photoTasks);

                return dadosPlace;

            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
