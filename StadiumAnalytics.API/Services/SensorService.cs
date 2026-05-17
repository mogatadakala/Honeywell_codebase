using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StadiumAnalytics.API.Models.Dtos;
using StadiumAnalytics.API.Models.Entities;
using StadiumAnalytics.API.Repositories.IRepositories;
using StadiumAnalytics.API.Services.IServices;

namespace StadiumAnalytics.API.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;
        private readonly IMapper _mapper;

        public SensorService(ISensorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddEventAsync(CreateSensorEventRequest sensorEvent)
        {
            var sensorEntity = _mapper.Map<SensorEvent>(sensorEvent);
            await _repository.AddAsync(sensorEntity);
        }

        public async Task AddBackgroundEventAsync(SensorEvent sensorEvent)
        {
            await _repository.AddAsync(sensorEvent);
        }

        public async Task<List<SensorSummaryDto>> GetSummaryAsync(
            string? gate,
            string? type,
            DateTime? startTime,
            DateTime? endTime)
        {
            var query = _repository.Query();

            if (!string.IsNullOrEmpty(gate))
            {
                query = query.Where(x => x.Gate == gate);
            }

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(x => x.Type == type);
            }

            if (startTime.HasValue)
            {
                query = query.Where(x => x.Timestamp >= startTime.Value);
            }

            if (endTime.HasValue)
            {
                query = query.Where(x => x.Timestamp <= endTime.Value);
            }

            return await query
                .GroupBy(x => new { x.Gate, x.Type })
                .Select(g => new SensorSummaryDto
                {
                    Gate = g.Key.Gate,
                    Type = g.Key.Type,
                    NumberOfPeople = g.Sum(x => x.NumberOfPeople)
                })
                .ToListAsync();
        }
    }
}
