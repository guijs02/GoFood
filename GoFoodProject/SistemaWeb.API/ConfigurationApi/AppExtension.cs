namespace GoFood.Api.ConfigurationApi
{
    public static class AppExtension
    {
        public static void ConfigureCors(this WebApplication app)
        {
            app.UseCors(
                c => { 

                // c.WithOrigins([Configuration.FrontendUrl, Configuration.BackendUrl])
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();
                }
            );
        }
        public static void ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
