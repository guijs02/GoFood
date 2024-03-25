using System.ComponentModel.DataAnnotations;

namespace GoFood.Domain.Google.Places.Request
{
    public class PlacesRequest
    {
        [Required]
        public string type => "restaurant";
        [Required]
        public string radius { get; set; }
        [Required]
        public double lat { get; set; }
        [Required]
        public double lng { get; set; }
        [Required]
        public FiltroPlaces filtroPlaces { get; set; } = new FiltroPlaces();
    }

    public class FiltroPlaces
    {
        public bool isOpen { get; set; }
        public int qtdRating { get; set; }
    }
}
