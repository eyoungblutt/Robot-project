using Microsoft.EntityFrameworkCore;

namespace Robot_project.Model
{

    public class LocationContext : DbContext
    {
        public LocationContext(DbContextOptions<LocationContext> options)
            : base(options)
        {

        }

        public DbSet<Location> Locations { get; set; }
    }
}
