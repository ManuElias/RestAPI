using Microsoft.EntityFrameworkCore;

namespace Rocket.DataAccess
{
    public class RocketDbContext : DbContext
    {

        public DbSet<Person> Persons { get; set; } = default!;

        public RocketDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
