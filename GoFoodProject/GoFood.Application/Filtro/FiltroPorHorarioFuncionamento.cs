using GoFood.Domain.Google.Places;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Filtro
{
    public class FiltroPorHorarioFuncionamento : IFiltroPesquisa
    {
        
        public List<ResultPlaces> Filtrar(Root root, PlacesRequest placesRequest)
        {
            if (placesRequest.filtroPlaces.isOpen)
            {
                var places = root.results.Where(place => place.opening_hours.open_now).ToList();
                return places;
            }
            return new FiltroPorAvaliacao().Filtrar(root, placesRequest);
        }
    }
}
