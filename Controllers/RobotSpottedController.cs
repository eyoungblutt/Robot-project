using Microsoft.AspNetCore.Mvc;
using Robot_project.Model;
using Robot_project.Services;
using System.Text.Json;

namespace Robot_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RobotSpottedController : ControllerBase
    {
        //    private static readonly string[] Summaries = new[]
        //    {
        //    "Parramatta River"
        //};

        private readonly ILogger<RobotSpottedController> _logger;
        private readonly LocationService _service;
        private LocationContext _context;

        private List<Location> _locations = new List<Location>()
        {
            //hard coded list of locations
            new Location()
            {
                Name = "Pacific Ocean",
                Latitude = 150,
                Longitude = 30
            }

        };
        public RobotSpottedController(LocationContext context, LocationService service, ILogger<RobotSpottedController> logger)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _logger.LogCritical(new EventId(), "Created Controller" );
        }

        [HttpGet(Name = "RobotSpotted")]
        public IEnumerable<Location> Get()
        {
            return _context.Locations;
        }
        [HttpPost(Name = "RobotSpotted")]
        public async Task<string> Post(Location location)
        {
            _logger.Log(LogLevel.Information, new EventId(), null, "Finding the nearest water to" + location.Name,null);
            var x = await _service.GetNearestRiverFromLocation(location);
           var xy = JsonSerializer.Deserialize<locationOfWater>(x);

            return $"The nearest body of water to {location.Name} is {xy}"; // possibly deserialize in x??
            //could use search - and they could send name of city, street, street number etc? Then use that to find the nearest water source.
            // water near me - search this and return the first 

            // have stored data and then have whe they hit the API have hem return closest to the stored data?? AN IF STATEMENT?

            //to hardcode in a locaiton - make async task - Location and have it return _location.First();
        }


    }
}