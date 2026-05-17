using StadiumAnalytics.API.Models.Entities;
using StadiumAnalytics.API.Services.IServices;

namespace StadiumAnalytics.API.BackgroundServices
{
    public class SensorEventSimulatorService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SensorEventSimulatorService> _logger;

        private readonly string[] gates =
        {
            "Gate A",
            "Gate B",
            "Gate C"
        };

        private readonly string[] types =
        {
            "enter",
            "exit"
        };

        public SensorEventSimulatorService(
            IServiceProvider serviceProvider,
            ILogger<SensorEventSimulatorService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            var random = new Random();

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var sensorService =
                    scope.ServiceProvider.GetRequiredService<ISensorService>();

                var sensorEvent = new SensorEvent
                {
                    Gate = gates[random.Next(gates.Length)],
                    Type = types[random.Next(types.Length)],
                    NumberOfPeople = random.Next(1, 50),
                    Timestamp = DateTime.UtcNow
                };

                await sensorService.AddBackgroundEventAsync(sensorEvent);

                _logger.LogInformation(
                    "Event Created: {@SensorEvent}",
                    sensorEvent);

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
