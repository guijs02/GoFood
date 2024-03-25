using GoFood.Domain.Google.Places;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Domain.Interfaces.Filtro
{
    public interface IFiltroPesquisa
    {
        public List<ResultPlaces> Filtrar(Root root, PlacesRequest placesRequest);
    }
}
