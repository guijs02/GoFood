namespace GoFood.Domain.Google.Places
{
    public class Geometry
    {
        public Bounds bounds { get; set; }
        public Location location { get; set; }
        public string location_type { get; set; }
        public Bounds viewport { get; set; }
    }
}