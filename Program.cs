using Robot_project.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddSingleton<LocationService>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//adding services
//- location services - a method that would take in a location and add it to the website as an endpoint so you can get the location.
// check out todays recording from around 3 hours - a bit before. 

//https://nominatim.openstreetmap.org/reverse?format=json&lat=-32&lon=151.2082848 - this is what we want to end point to be so we enter in a longitude and a latitude to send to the API maps.
//client.DefaultRequestHeaders.Add("User-Agent", "C# App");

//https://nominatim.org/release-docs/develop/api/Lookup/ - what are there expectations for the API end points

// - STORAGE DATA - REPOSITORIES
//you can store the locaitons of water in a private list
//you can hardcode the list with several locations - e.g pacific ocean, indian ocean - 

