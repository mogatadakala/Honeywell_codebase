using System.ComponentModel.DataAnnotations;

namespace StadiumAnalytics.API.Models.Entities
{
    public class SensorEvent
    {
        public int Id { get; set; }
        [Required]
        public string Gate { get; set; } = string.Empty;
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
    }
}
