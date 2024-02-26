using Microsoft.Extensions.Primitives;

namespace GoFood.GoogleAPI
{
    public static class GoogleAPI
    {
        private const string API_KEY = "API:Key";
        private static string? _googleKey;
        public static string GoogleApiKey => _googleKey;

        public static void GetApiKey(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            ArgumentNullException.ThrowIfNull(configuration[API_KEY]);

            _googleKey = configuration[API_KEY];
        }
    }
}
