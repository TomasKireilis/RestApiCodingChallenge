using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class WeatherForecast : IEntity
    {
        public long Id { get; set; }
        public long WeatherForecastId { get; set; }

        public int LocationId { get; set; }

        public DateTime Date { get; set; }

        public string WeatherState { get; set; }

        public float WindSpeed { get; set; }

        public float WindDirection { get; set; }

        public float AirPressure { get; set; }
    }
}