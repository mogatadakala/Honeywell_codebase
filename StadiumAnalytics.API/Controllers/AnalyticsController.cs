using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StadiumAnalytics.API.Models.Dtos;
using StadiumAnalytics.API.Models.Entities;
using StadiumAnalytics.API.Services.IServices;

namespace StadiumAnalytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly ISensorService _sensorService;

        public AnalyticsController(ISensorService sensorService)
        {
            _sensorService = sensorService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary(
            [FromQuery] string? gate,
            [FromQuery] string? type,
            [FromQuery] DateTime? startTime,
            [FromQuery] DateTime? endTime)
        {
            var result = await _sensorService.GetSummaryAsync(
                gate,
                type,
                startTime,
                endTime);

            return Ok(result);
        }

        [HttpPost("event")]
        public async Task<IActionResult> CreateEvent(
    [FromBody] CreateSensorEventRequest request)
        {
            var sensorEvent = _sensorService.AddEventAsync(request);

            return Ok(new
            {
                Message = "Event created successfully"
            });
        }
    }

}
