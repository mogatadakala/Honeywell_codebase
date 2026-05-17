using StadiumAnalytics.API.DbContexts;
using StadiumAnalytics.API.Models.Entities;
using StadiumAnalytics.API.Repositories.IRepositories;

namespace StadiumAnalytics.API.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationDbContext _context;

        public SensorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SensorEvent sensorEvent)
        {
            await _context.SensorEvents.AddAsync(sensorEvent);

            await _context.SaveChangesAsync();
        }

        public IQueryable<SensorEvent> Query()
        {
            return _context.SensorEvents.AsQueryable();
        }
    }
}
