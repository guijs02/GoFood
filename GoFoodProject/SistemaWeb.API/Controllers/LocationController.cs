using GoFood.GoogleAPI;
using Microsoft.AspNetCore.Mvc;
using GoFood.Application.API_s;


namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpGet("{endereco}")]
        public async Task<IActionResult> GetLocationAsync(string endereco)
        {
            var key = GoogleAPI.GoogleApiKey;

            var response = await _http.GetAsync($"{GeoCodeAPI.BaseAdress}json?address={endereco.Trim()}&key={key}");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

    }
}
