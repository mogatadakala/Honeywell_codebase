namespace StadiumAnalytics.API.Models.Dtos
{
    public class SensorSummaryDto
    {
        public string Gate { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public int NumberOfPeople { get; set; }
    }
}
