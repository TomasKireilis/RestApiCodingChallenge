using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApi.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly string _requestBaseUrl;

        public WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _requestBaseUrl = configuration["ConnectionStrings.WeatherForecastServiceBaseUrl"];
        }

        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public async Task<List<WeatherForecast>> GetForecastsInRegion(int locationId)
        {
            List<WeatherForecast> weatherForecast;
            try
            {
                var response = await _httpClient.GetAsync($"{_requestBaseUrl}/location/{locationId}");
                weatherForecast = await JsonSerializer.DeserializeAsync<List<WeatherForecast>>(await response.Content.ReadAsStreamAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return weatherForecast;
        }

        public async Task<List<WeatherForecast>> GetForecastsInRegion(List<int> locationIds)
        {
            List<WeatherForecast> weatherForecast = new List<WeatherForecast>();
            foreach (var locationId in locationIds)
            {
                var response = await GetForecastsInRegion(locationId);
                weatherForecast.AddRange(response);
            }

            return weatherForecast;
        }
    }
}