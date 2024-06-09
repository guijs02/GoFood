namespace GoFood.Api.ConfigurationApi
{
    public static class BuildExtension
    {
        public static void AddAllServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddCors();
        }
    }
}
