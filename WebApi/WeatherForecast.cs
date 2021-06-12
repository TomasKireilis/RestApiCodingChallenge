using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace WebApi
{
    public class WeatherForecast
    {
        public WeatherForecast(int locationId)
        {
            LocationId = locationId;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        public int LocationId { get; set; }

        [JsonProperty("applicable_date")]
        public DateTime ApplicableDate { get; set; }

        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }

        [JsonProperty("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }

        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }

        [JsonProperty("wind_direction")]
        public float WindDirection { get; set; }

        [JsonProperty("air_pressure")]
        public float AirPressure { get; set; }
    }
}