using GoFood.Domain.Google.Places;
using GoFood.Domain.Google.Places.Request;

namespace GoFood.Application.Filtro
{
    public class FiltroPesquisa
    {
        public List<ResultPlaces> GerenciarFiltros(Root root, PlacesRequest placesRequest)
        {
            if (VerificarSeTodosOsFiltrosEstaoPreenchido(placesRequest))
            {
                ///regra para fazer com todos os filtros
                var places = root.results.Where(place => place.opening_hours.open_now && place.rating >= placesRequest.filtroPlaces.qtdRating).ToList();
                return places;
            }   

            return new FiltroPorHorarioFuncionamento().Filtrar(root, placesRequest);
        }

        public bool VerificarSeTodosOsFiltrosEstaoPreenchido(PlacesRequest places)
        {
            return places.filtroPlaces.isOpen != default &&
                   places.filtroPlaces.qtdRating != default;
        }
    }
}
