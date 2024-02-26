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

        public async Task<Root> GetPlacesAroundAsync(PlacesRequest placesRequest)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Places", placesRequest);

                var obj = await response.ReadJsonAsObject<Root>();
                
                return obj;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
