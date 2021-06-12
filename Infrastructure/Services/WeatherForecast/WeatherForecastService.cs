using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Common;

namespace Infrastructure.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IDateService _dateService;
        private readonly string _requestBaseUrl;
        private readonly string _datePattern = "yy/MM/dd";

        public WeatherForecastService(HttpClient httpClient, IDateService dateService, string requestBaseUrl)
        {
            _httpClient = httpClient;
            _dateService = dateService;
            _requestBaseUrl = requestBaseUrl;
        }

        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<List<WeatherForecastDto>> GetForecastsInRegion(int locationId, DateTime time)
        {
            List<WeatherForecastDto> weatherForecast = null;

            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_requestBaseUrl}/location/{locationId}/{_dateService.GetDateInFormat(time, _datePattern)}");

                weatherForecast = await JsonSerializer.DeserializeAsync<List<WeatherForecastDto>>(await response.Content.ReadAsStreamAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return weatherForecast = new List<WeatherForecastDto>();
        }

        public async Task<List<WeatherForecastDto>> GetForecastsInRegion(List<int> locationIds, DateTime time)
        {
            List<WeatherForecastDto> weatherForecast = new List<WeatherForecastDto>();
            foreach (var locationId in locationIds)
            {
                var response = await GetForecastsInRegion(locationId, time);
                weatherForecast.AddRange(response);
            }

            return weatherForecast;
        }
    }
}