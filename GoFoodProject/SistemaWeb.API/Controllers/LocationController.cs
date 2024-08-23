using GoFood.Api;
using GoFood.Application.API_s;
using Microsoft.AspNetCore.Mvc;


namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        private readonly string Key;
        public LocationController(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
            Key = GoogleAPI.GetApiKey();
        }

        [HttpGet("{endereco}")]
        public async Task<IActionResult> GetLocationAsync(string endereco)
        {
            var request = GeoCodeAPI.BuildUrlRequest(endereco, Key);

            var response = await _http.GetAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

    }
}
