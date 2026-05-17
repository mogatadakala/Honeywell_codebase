using StadiumAnalytics.API.Models.Entities;

namespace StadiumAnalytics.API.Repositories.IRepositories
{
    public interface ISensorRepository
    {
        Task AddAsync(SensorEvent sensorEvent);

        IQueryable<SensorEvent> Query();
    }
}
