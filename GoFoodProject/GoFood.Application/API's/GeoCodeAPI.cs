namespace GoFood.Application.API_s
{
    public static class GeoCodeAPI
    {
        public const string BaseAdress = "https://maps.googleapis.com/maps/api/geocode/";
        public const string EndPoint = "api/Location/{0}";
        public const string QueryTemplate = "json?address={0}&key={1}";

        public static string BuildUrlRequest(string address, string key)
        {
            return BaseAdress + string.Format(QueryTemplate, address, key);  
        }
    }
}
