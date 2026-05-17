using System.ComponentModel.DataAnnotations;

namespace StadiumAnalytics.API.Models.Dtos
{
    public class CreateSensorEventRequest
    {
        [Required(ErrorMessage = "Gate is required.")]
        [MaxLength(50)]
        public string Gate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Timestamp is required.")]
        public DateTime Timestamp { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "NumberOfPeople must be greater than zero.")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        [RegularExpression("enter|exit",
            ErrorMessage = "Type must be either 'enter' or 'exit'.")]
        public string Type { get; set; } = string.Empty;
    }
}
