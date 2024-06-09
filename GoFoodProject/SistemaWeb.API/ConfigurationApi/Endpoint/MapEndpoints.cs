using GoFood.Application.API_s;
namespace GoFood.Api.ConfigurationApi.Endpoint
{
    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("api/Photo/{photoRef}", (string photoRef) =>
            {
                var key = GoogleAPI.GoogleApiKey;

                return PhotosAPI.BuildUrl(photoRef, key);

            });
        }
    }
}