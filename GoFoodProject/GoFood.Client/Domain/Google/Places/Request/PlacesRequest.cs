namespace SistemaRecomendacaoRestuaruantes.Domain.Google.Places.Request
{
    public struct PlacesRequest
    {
        public string type => "restaurant";
        public string radius { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
