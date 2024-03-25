using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoFood.Application.API_s
{
    public static class PlacesAPI
    {
        public const string BaseAdress = "https://maps.googleapis.com/maps/api/place/nearbysearch/";
        public const string BaseAdressAutoComplete = "https://maps.googleapis.com/maps/api/place/autocomplete/";
        public const string QueryTemplatePlace = "json?key={0}&location={1},{2}&radius={3}&type={4}";
        public const string QueryTemplateAutoComplete = "json?input={0}&types=geocode&key={1}";

        public const string EndpointAutoComplete = "api/Places/{0}";
        public const string Endpoint = "api/Places";
    }
}
