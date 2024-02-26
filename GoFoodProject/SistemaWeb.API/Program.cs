using GoFood.GoogleAPI;
using GoFood.Domain.API_s;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

GoogleAPI.GetApiKey(builder.Configuration);

app.MapGet("api/Photo/{photoRef}", (string photoRef) =>
{
    var key = GoogleAPI.GoogleApiKey;
    
    var photo = $"{PhotosAPI.BaseUrl}maxwidth=400&minwidth=130&photoreference={photoRef}&key={key}";

    return photo;
});

app.UseCors(c =>

c.AllowAnyOrigin()
 .AllowAnyHeader()
 .AllowAnyMethod()

);
app.UseAuthorization();

app.MapControllers();

app.Run();
