using GoFood.Application.API_s;
using GoFood.Application.Dtos;
using GoFood.Application.Filtro;
using GoFood.Application.Services.Interfaces;
using GoFood.Domain.Extension;
using GoFood.Domain.Google.Places.AutoComplete;
using GoFood.Domain.Google.Places.Request;
using System.Net.Http.Json;
using UserInputModel = GoFood.Application.InputModels.UserInputModel;

namespace GoFood.Application.Services
{
    public class PlacesService : BaseService, IPlacesService
    {
        private HttpClient _httpClient;
        public PlacesService()
        {
            _httpClient = ConfigureHttpUrl();
        }

        public async Task<List<ResultPlacesDto>> GetPlacesAroundAsync(UserInputModel userInputModel, Location location)
        {
            try
            {

                PlacesRequest placesRequest = BuildPlaceRequest(userInputModel, location);

                var response = await _httpClient.PostAsJsonAsync(PlacesAPI.Endpoint, placesRequest);

                var root = await response.ReadJsonAsObject<Root>();

                var ListaFiltrada = new FiltroPesquisa().
                                        GerenciarFiltros(root, placesRequest);

                var placesDto = (from place in ListaFiltrada
                                select
                                new ResultPlacesDto
                                (place.name,
                                 place.vicinity,
                                 place.icon,
                                 place.rating,
                                 place.opening_hours.open_now,
                                 place.photos,
                                 place.photos?.FirstOrDefault().photo_reference
                                )).ToList();

                return placesDto;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetPlacesByAutoComplete(string input)
        {
            try
            {
                var request = string.Format(PlacesAPI.EndpointAutoComplete, input);

                var response = await _httpClient.GetAsync(request);

                var root = await response.ReadJsonAsObject<RootPrediction>();

                return root.predictions.Select(x => x.description);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: "+e.Message);
                throw;
            }
        }
        public PlacesRequest BuildPlaceRequest(UserInputModel userInputModel, Location location) =>
        new()
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
    }
}
