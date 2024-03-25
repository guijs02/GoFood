using System.Net.Http.Headers;

namespace GoFood.Application.Services
{
    public class BaseService
    {
        public const string BASE_URL = "https://localhost:7164";
        public HttpClient ConfigureHttpUrl() => new() { BaseAddress = new Uri(BASE_URL) };
       
    }
}
