namespace GoFood.Api.ConfigurationApi
{
    public static class AppExtension
    {
        public static void ConfigureCors(this WebApplication app)
        {
            app.UseCors(
                c =>
                c.WithOrigins([Configuration.FrontendUrl, Configuration.BackendUrl])
                .AllowAnyHeader()
                .AllowAnyMethod()
            );
        }
        public static void ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
