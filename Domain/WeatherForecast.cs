using System;

namespace Domain
{
    public class WeatherForecast
    {
        public WeatherForecast(int locationId)
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