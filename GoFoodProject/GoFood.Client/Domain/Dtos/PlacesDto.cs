using SistemaRecomendacaoRestuaruantes.Domain.Google.Places;

namespace SistemaRecomendacaoRestuaruantes.Domain.Dtos
{
    public class PlacesDto
    {
        public List<ResultPlacesDto> ResultPlaces { get; set; }
    }

}
public class ResultPlacesDto
{
    public string name { get; set; }
    public string PhotoReference { get; set; }
    public string vicinity { get; set; }
    public bool IsOpen { get; set; }
    public double rating { get; set; }
    public List<Photo> photos { get; set; }
    public string icon { get; set; }
    public Dictionary<string, string> DictionaryFotos { get; set; }

    public static implicit operator ResultPlacesDto(ResultPlaces places)
    {
        return new ResultPlacesDto
        {
            DictionaryFotos = places.DictionaryFotos,
            icon = places.icon,
            rating = places.rating,
            IsOpen = places.opening_hours.open_now,
            photos = places.photos,
            name = places.name,
            PhotoReference = places.PhotoReference,
            vicinity = places.vicinity,
        };
    }
}
