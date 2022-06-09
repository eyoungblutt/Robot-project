using System.Net.Http;

namespace Robot_project.Services
{
   
    public class LocationService
    {

        private readonly HttpClient _httpClient;
        private readonly ILogger<LocationService> _logger;

        public LocationService(HttpClient client, ILogger<LocationService> logger, IConfiguration config)
        {
            _httpClient = client;
           // client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            _logger = logger;
            _logger.LogCritical(new EventId(), null, "Created Service");
            _httpClient = client;
            IConfigurationSection section = config.GetSection("HttpCustomHeaders:User-agent");
            client.DefaultRequestHeaders.Add(section.Key, section.Value); //adding to the config file

        }
        public async Task<string> GetNearestRiverFromLocation(Location location)
        {

            //client.DefaultRequestHeaders.Add("Name", "My App");
            HttpResponseMessage x = await _httpClient.GetAsync($"https://nominatim.openstreetmap.org/?addressdetails=1&q=water+near+{location.Name}+{location.postcode}&format=json&limit=1");
            
            
            //  HttpResponseMessage x = await _httpClient.GetAsync($"https://nominatim.openstreetmap.org/reverse?format=json&lat=location.Latitude&lon=location.Longitude");
            //need to somehow add endpoints here that get us body of water based on a location.
            return await x.Content.ReadAsStringAsync();

            //copy all data you want to get from browser and paste into a class - a new class 
        }
    }

}
