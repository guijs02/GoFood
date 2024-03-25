using GoFood.Application.API_s;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application
{
    public class UriBuilderCustom
    {
        public string Query { get; set; }

        public static string BuildPlacesUrl(string baseUrl, string key, PlacesRequest placesRequest)
        {
            return baseUrl + string.Format(PlacesAPI.QueryTemplatePlace, key, placesRequest.lat, placesRequest.lng, placesRequest.radius, placesRequest.type);
        }
        public static string BuildAutoCompleteUrl(string baseUrl, string key, string input)
        {
            return baseUrl + string.Format(PlacesAPI.QueryTemplateAutoComplete, input, key);
        }
    }
}
