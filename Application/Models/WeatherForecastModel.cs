using System;

namespace Application.Models
{
    public class WeatherForecastModel
    {
        public WeatherForecastModel(int locationId)
        {
            LocationId = locationId;
        }

        public long Id { get; set; }

        public int LocationId { get; set; }

        public DateTime Date { get; set; }

        public string WeatherState { get; set; }

        public float WindSpeed { get; set; }

        public float WindDirection { get; set; }

        public float AirPressure { get; set; }
    }
}