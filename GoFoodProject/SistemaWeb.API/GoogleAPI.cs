using Microsoft.Extensions.Primitives;

namespace GoFood.Api
{
    public static class GoogleAPI
    {
        private const string API_KEY = "API:Key";
        private static string? _googleKey;
        private const string API_KEY_NOT_FOUND = "A chave da API não foi encontrada!";
        public static string GoogleApiKey => _googleKey;

        public static string GetApiKey(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            ArgumentNullException.ThrowIfNull(configuration[API_KEY], API_KEY_NOT_FOUND);

            _googleKey = configuration[API_KEY];

            return _googleKey;
        }
    }
}
