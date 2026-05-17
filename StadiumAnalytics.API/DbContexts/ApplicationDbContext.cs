using Microsoft.EntityFrameworkCore;
using StadiumAnalytics.API.Models.Entities;

namespace StadiumAnalytics.API.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SensorEvent> SensorEvents { get; set; }
    }
}
