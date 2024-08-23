using System.Net.Http.Headers;

namespace GoFood.Application.Services
{
    public class BaseService
    {
        public const string BASE_URL = "http://localhost:9000/";
        public HttpClient ConfigureHttpUrl() => new() { BaseAddress = new Uri(BASE_URL) };
       
    }
}
