using System;

namespace Application
{
    public class WeatherForecastModel
    {
        public WeatherForecastModel(int locationId)
        {
            LocationId = locationId;
        }

        public int Id { get; set; }

        public int LocationId { get; set; }

        public DateTime ApplicableDate { get; set; }

        public string WeatherStateName { get; set; }

        public string WeatherStateAbbr { get; set; }

        public float WindSpeed { get; set; }

        public float WindDirection { get; set; }

        public float AirPressure { get; set; }
    }
}