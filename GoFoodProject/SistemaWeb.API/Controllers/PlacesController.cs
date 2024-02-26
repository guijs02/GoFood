using GoFood.GoogleAPI;
using GoFood.Domain.Google.Places.Request;
using Microsoft.AspNetCore.Mvc;
using GoFood.Domain.API_s;

namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlacesController(HttpClient httpClient) : ControllerBase
    {
        private readonly HttpClient _httpClient = httpClient;

        [HttpPost]
        public async Task<IActionResult> GetNearbyPlaces(PlacesRequest placesRequest)
        {
            try
            {
                var key = GoogleAPI.GoogleApiKey;

                var response = await _httpClient.GetAsync(
                    $"{PlacesAPI.BaseAdress}json?key={key}&location={placesRequest.lat},{placesRequest.lng}&radius={placesRequest.radius}&type={placesRequest.type}"
                    );

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
