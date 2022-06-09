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
            _logger = logger;
            _logger.LogCritical(new EventId(), null, "Created Service");
            _httpClient = client;
            IConfigurationSection section = config.GetSection("HttpCustomHeaders:User-agent");
            client.DefaultRequestHeaders.Add(section.Key, section.Value); 

        }
        public async Task<string> GetNearestRiverFromLocation(Location location)
        {

            HttpResponseMessage x = await _httpClient.GetAsync($"https://nominatim.openstreetmap.org/?addressdetails=1&q=water+near+{location.Suburb}+{location.State}+{location.Country}&format=json&limit=1");
            
            return await x.Content.ReadAsStringAsync();

        }
    }

}
