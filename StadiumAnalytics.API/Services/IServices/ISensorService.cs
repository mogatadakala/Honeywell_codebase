using StadiumAnalytics.API.Models.Dtos;
using StadiumAnalytics.API.Models.Entities;

namespace StadiumAnalytics.API.Services.IServices
{
    public interface ISensorService
    {
        Task AddEventAsync(CreateSensorEventRequest sensorEvent);
        Task AddBackgroundEventAsync(SensorEvent sensorEvent);

        Task<List<SensorSummaryDto>> GetSummaryAsync(
            string? gate,
            string? type,
            DateTime? startTime,
            DateTime? endTime);
    }
}
