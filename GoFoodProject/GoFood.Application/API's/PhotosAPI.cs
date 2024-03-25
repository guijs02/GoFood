using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GoFood.Application.API_s
{
    public static class PhotosAPI
    {
        public const string BaseUrl = "https://maps.googleapis.com/maps/api/place/";
        public const string Endpoint = "api/Photo/{0}";
        public const string QueryTemplate = "{0}photo?maxwidth=400&minwidth=130&photoreference={1}&key={2}";
        public static string BuildUrl(string photoRef, string key) => string.Format(QueryTemplate, BaseUrl, photoRef, key);
    }
}
