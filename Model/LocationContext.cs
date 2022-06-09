using Microsoft.EntityFrameworkCore;

namespace Robot_project.Model
{
    // to use in memory 
    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options)
            : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
    }
}
