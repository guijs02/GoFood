using Microsoft.Extensions.Primitives;

namespace GoFood.Api
{
    public static class GoogleAPI
    {
        private const string API_KEY = "ApiKey";
        private static string? _googleKey;
        private const string API_KEY_NOT_FOUND = "A chave da API não foi encontrada!";
        public static string GoogleApiKey => _googleKey;

        public static string GetApiKey()
        {
            var key = Environment.GetEnvironmentVariable(API_KEY);
            
            ArgumentNullException.ThrowIfNull(key, API_KEY_NOT_FOUND);

            _googleKey = key;

            return _googleKey;
        }
    }
}
