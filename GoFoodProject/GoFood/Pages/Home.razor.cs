using GoFood.Application.Dtos;
using GoFood.Application.InputModels;
using GoFood.Application.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace GoFood.App.Pages
{
    public class HomePage : ComponentBase
    {
        #region Properties
        public List<ResultPlacesDto>? PlacesDto { get; set; }
        public bool isVisibilityFiltro;
        const string UrlDefault = "https://sdumont.lncc.br/images/projects/no-image.png";
        public UserInputModel UserInputModel = new();
        #endregion
        #region Services
        [Inject]
        public IPlacesService _placeService { get; set; } = null!;
        [Inject]
        public ILocationService _locationService { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Methods

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }
        public void OpenFiltro()
        {
            isVisibilityFiltro = true;
        }
        public async Task<IEnumerable<string>> SearchAsync(string input)
                        => string.IsNullOrEmpty(input) ?
                           Enumerable.Empty<string>() :
                           await _placeService.GetPlacesByAutoComplete(input);

        public async Task GetPlacesAround()
        {
            try
            {
                PlacesDto = await _locationService.GetLocationAsync(UserInputModel);
            }
            catch (Exception e)
            {
                Snackbar.Add(e.Message, Severity.Error);
            }
        }

        public string ObterFoto(ResultPlacesDto resultPlaces) =>
                     resultPlaces.Photos is null ?
                     UrlDefault :
                     resultPlaces.DictionaryFotos[resultPlaces.PhotoReference];

        public int ConvertRating(double rating) => (int)rating;

        #endregion
    }
}
