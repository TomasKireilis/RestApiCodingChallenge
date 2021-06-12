using System;
using System.Text.Json.Serialization;

namespace Infrastructure.Services.WeatherForecast
{
    public class WeatherForecastDto
    {
        public WeatherForecastDto(int locationId)
        {
            LocationId = locationId;
        }

        public WeatherForecastDto()
        {
        }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        public int LocationId { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }

        [JsonPropertyName("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonPropertyName("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonPropertyName("wind_direction")]
        public float WindDirection { get; set; }

        [JsonPropertyName("air_pressure")]
        public float AirPressure { get; set; }
    }
}