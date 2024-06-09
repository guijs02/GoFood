using GoFood.Application.API_s;
using GoFood.Domain.Google.Places.Request;
using System.Globalization;

namespace GoFood.Application
{
    public class UriBuilderCustom
    {
        public string Query { get; set; }

        public static string BuildPlacesUrl(string baseUrl, string key, PlacesRequest placesRequest)
        {
            var lat = placesRequest.lat.ToString(CultureInfo.InvariantCulture);
            var log = placesRequest.lng.ToString(CultureInfo.InvariantCulture);

            return baseUrl + string.Format(PlacesAPI.QueryTemplatePlace, key, lat, log, placesRequest.radius, placesRequest.type);
        }
        public static string BuildAutoCompleteUrl(string baseUrl, string key, string input)
        {
            return baseUrl + string.Format(PlacesAPI.QueryTemplateAutoComplete, input, key);
        }
    }
}
