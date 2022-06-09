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
       
        private readonly ILogger<RobotSpottedController> _logger;
        private readonly LocationService _service;
        private LocationContext _context;

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
            _logger.Log(LogLevel.Information, new EventId(), null, "Finding the nearest water to" + location.Suburb,null);
            var x = await _service.GetNearestRiverFromLocation(location);
           LocationOfWater[] xy = JsonSerializer.Deserialize<LocationOfWater[]>(x);

           
                return $"The nearest body of water to {location.Suburb}, {location.Country} is {xy[0].display_name}";
           
        }


    }
}