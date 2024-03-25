using GoFood.Domain.Google.Places;
using GoFood.Domain.Google.Places.Request;
using System.Text.RegularExpressions;

namespace GoFood.Application.Filtro
{
    public class FiltroPorAvaliacao : IFiltroPesquisa
    {
        public List<ResultPlaces> Filtrar(Root root, PlacesRequest placesRequest)
        {
            if (!string.IsNullOrEmpty(placesRequest.filtroPlaces.qtdRating.ToString()))
            {
                 var places = root.results.Where(place => place.rating >= placesRequest.filtroPlaces.qtdRating).ToList();
                return places;
            }
            return root.results;
        }
    }
}
