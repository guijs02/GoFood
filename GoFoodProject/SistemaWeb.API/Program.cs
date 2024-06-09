using GoFood.Api;
using GoFood.Api.ConfigurationApi;
using GoFood.Api.ConfigurationApi.Endpoint;

var builder = WebApplication.CreateBuilder(args);

builder.AddAllServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.ConfigureSwagger();

GoogleAPI.GetApiKey(builder.Configuration);

app.MapEndpoints();

app.ConfigureCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
