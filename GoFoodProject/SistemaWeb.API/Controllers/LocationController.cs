using GoFood.Domain.Google.GeoCode;
using Microsoft.AspNetCore.Mvc;


namespace SistemaWeb.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : Controller
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public LocationController(HttpClient http, IConfiguration configuration)
        {
            _http = http;
            _configuration = configuration;
        }

        [HttpGet("{endereco}")]
        public async Task<IActionResult> GetLocationAsync(string endereco)
        {
            var key = _configuration["API:Key"];

            var response = await _http.GetAsync($"{GeoCodeAPI.BaseAdress}json?address={endereco.Trim()}&key={key}");

            var content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }

    }
}
