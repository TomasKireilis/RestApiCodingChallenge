using System;
using System.Text.Json.Serialization;

namespace Infrastructure.Services.WeatherForecast
{
    public class WeatherForecastDto
    {
        //for serialization
        public WeatherForecastDto()
        {
        }

        public WeatherForecastDto(int locationId)
        {
            LocationId = locationId;
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        public int LocationId { get; set; }

        [JsonPropertyName("created")]
        public DateTime Date { get; set; }

        [JsonPropertyName("weather_state_name")]
        public string WeatherState { get; set; }

        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_direction")]
        public float WindDirection { get; set; }

        [JsonPropertyName("air_pressure")]
        public float AirPressure { get; set; }
    }
}