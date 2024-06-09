using GoFood.Application.InputModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace GoFood.App.Components
{
    public class DialogComponent : ComponentBase
    {
        public string _style => $"height:{Height}%; width:{Width}%;";

        private bool _checked3 = false;

        [Parameter]
        public bool IsVisibility { get; set; }

        [Parameter]
        public string? Height { get; set; }

        [Parameter]
        public EventCallback<bool> VisibilityChanged { get; set; }

        [Parameter]
        public EventCallback<UserInputModel> FiltroSavedChanged { get; set; }

        [Parameter]
        public string? Width { get; set; }

        [Parameter]
        public UserInputModel? userInput { get; set; }

        public string[] labels = new string[] { "400 m", "500 m", "600 m", "700 m", "800 m", "900 m", "1 km" };

        public void Close()
        {
            IsVisibility = false;
            VisibilityChanged.InvokeAsync(IsVisibility);
        }
        public void SaveChanges()
        {
            FiltroSavedChanged.InvokeAsync(userInput);
            Close();
        }
        public void OnBackdropClick(MouseEventArgs e)
        {
            IsVisibility = false;
        }
    }
}
