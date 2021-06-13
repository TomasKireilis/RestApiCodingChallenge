using Application.Models;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherForecastService> _logger;
        private readonly string _requestBaseUrl;

        public WeatherForecastService(HttpClient httpClient, ILogger<WeatherForecastService> logger, string requestBaseUrl)
        {
            _httpClient = httpClient;
            _logger = logger;

            _requestBaseUrl = requestBaseUrl;
        }

        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<WeatherForecastModel> GetForecastInRegion(int locationId, DateTime time)
        {
            List<WeatherForecastDto> weatherForecast;

            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_requestBaseUrl}/location/{locationId}/{time.Year}/{time.Month}/{time.Day}");

                var content = await response.Content.ReadAsStreamAsync();

                weatherForecast = await JsonSerializer.DeserializeAsync<List<WeatherForecastDto>>(content);
            }
            catch (Exception e)
            {
                _logger.LogError("Error while fetching data from weather forecast api. {@error}", e.Message);
                throw;
            }

            if (weatherForecast.Any())
            {
                var closestWeatherForecastByTime = weatherForecast.OrderBy(t => Math.Abs((t.Date - time).Ticks)).First();

                closestWeatherForecastByTime.LocationId = locationId;

                var weatherForecastModel = new WeatherForecastModel()
                {
                    AirPressure = closestWeatherForecastByTime.AirPressure,
                    Date = closestWeatherForecastByTime.Date,
                    Id = closestWeatherForecastByTime.Id,
                    LocationId = closestWeatherForecastByTime.LocationId,
                    WeatherState = closestWeatherForecastByTime.WeatherState,
                    WindDirection = closestWeatherForecastByTime.WindDirection,
                    WindSpeed = closestWeatherForecastByTime.WindSpeed
                };

                return weatherForecastModel;
            }
            _logger.LogWarning("No data found in {@locationId} time: {@time}", locationId, time);

            return null;
        }

        public async Task<List<WeatherForecastModel>> GetForecastsInRegion(List<int> locationIds, DateTime time)
        {
            List<WeatherForecastModel> weatherForecast = new List<WeatherForecastModel>();

            foreach (var locationId in locationIds)
            {
                var response = await GetForecastInRegion(locationId, time);
                weatherForecast.Add(response);
            }

            return weatherForecast;
        }
    }
}