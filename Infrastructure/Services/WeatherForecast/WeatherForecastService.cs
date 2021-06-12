using Application.Models;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string _requestBaseUrl;

        public WeatherForecastService(HttpClient httpClient, string requestBaseUrl)
        {
            _httpClient = httpClient;

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
            List<WeatherForecastModel> weatherForecast;

            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_requestBaseUrl}/location/{locationId}/{time.Year}/{time.Month}/{time.Day}");

                var content = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                weatherForecast = await JsonSerializer.DeserializeAsync<List<WeatherForecastModel>>(content, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (weatherForecast.Any())
            {
                var closestTime = weatherForecast.OrderBy(t => Math.Abs((t.Date - time).Ticks)).First();

                closestTime.LocationId = locationId;

                return closestTime;
            }
            Console.WriteLine($"No data found in {locationId} time: {time}");

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