using GoFood.Domain.Google.Places;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Filtro
{
    public interface IFiltroPesquisa
    {
        public List<ResultPlaces> Filtrar(Root root, PlacesRequest placesRequest);
    }
}
