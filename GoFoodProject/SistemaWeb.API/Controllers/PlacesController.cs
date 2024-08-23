using GoFood.Api;
using GoFood.Application;
using GoFood.Application.API_s;
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
        private readonly string Key;
        public PlacesController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            Key = GoogleAPI.GetApiKey();
        }

        [HttpPost]
        public async Task<IActionResult> GetNearbyPlaces(PlacesRequest placesRequest)
        {
            try
            {
                var requestUrl = UriBuilderCustom.BuildPlacesUrl(PlacesAPI.BaseAdress, Key, placesRequest);

                var response = await _httpClient.GetAsync(requestUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode(500, response.ReasonPhrase);
                }

                var content = await response.Content.ReadAsStringAsync();

                return Ok(content);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        [HttpGet("{input}")]
        public async Task<IActionResult> GetPlacesByAutoComplete(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return BadRequest();
                }

                var requestUrl = UriBuilderCustom.BuildAutoCompleteUrl(PlacesAPI.BaseAdressAutoComplete, Key, input);

                var response = await _httpClient.GetAsync(requestUrl);

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
