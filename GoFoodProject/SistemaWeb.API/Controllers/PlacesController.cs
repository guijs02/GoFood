using GoFood.Domain.Google.Places.Request;
using Microsoft.AspNetCore.Mvc;

namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string BasePath = "https://maps.googleapis.com/maps/api/place/nearbysearch/";
        public PlacesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> GetNearbyPlaces(PlacesRequest placesRequest)
        {
            try
            {
                var key = _configuration["API:Key"];

                var response = await _httpClient.GetAsync($"{BasePath}json?key={key}&location={placesRequest.lat},{placesRequest.lng}&radius={placesRequest.radius}&type={placesRequest.type}");

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode(500, response.StatusCode);
                }

                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
