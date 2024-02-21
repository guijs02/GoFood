using GoFood.Application.Services.Interfaces;
using GoFood.Domain.Extension;
using GoFood.Domain.Google.Places.Request;
using System.Net.Http.Json;
using System.Text;

namespace GoFood.Application.Services
{
    public class PlacesService : IPlacesService
    {
        private HttpClient _httpClient;
        public PlacesService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7164") };
        }

        public async Task<Root> GetPlacesAroundAsync(Location location)
        {
            try
            {
                var placesRequest = SetObjects(location);

                var response = await _httpClient.PostAsJsonAsync("api/Places", placesRequest);

                var obj = await response.ReadJsonAsObject<Root>();
                
                return obj;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public PlacesRequest SetObjects(Location location)
        {
            string radius = "600";

            return new PlacesRequest
            {
                lat = location.lat,
                lng = location.lng,
                radius = radius,
            };
        }
    }
}
