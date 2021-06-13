using Application;
using Application.Models;
using Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class WeatherForecastDataSeeder : IDataSeeder
    {
        private readonly WeatherForecastContext _weatherForecastContext;
        private readonly ILogger<WeatherForecastDataSeeder> _logger;

        public WeatherForecastDataSeeder(WeatherForecastContext weatherForecastContext, ILogger<WeatherForecastDataSeeder> logger)
        {
            _weatherForecastContext = weatherForecastContext;
            _logger = logger;
        }

        public async Task<bool> AlreadySeeded()
        {
            await _weatherForecastContext.Database.EnsureCreatedAsync();
            return _weatherForecastContext.WeatherForecast.Any();
        }

        public async Task Seed(List<WeatherForecastModel> weatherForecastModels)
        {
            _logger.LogInformation("Started seeding");
            if (!await AlreadySeeded())
            {
                var weatherForecasts = weatherForecastModels.Select(x => new WeatherForecast()
                {
                    AirPressure = x.AirPressure,
                    Date = x.Date,
                    WeatherForecastId = x.Id,
                    LocationId = x.LocationId,
                    WeatherState = x.WeatherState,
                    WindDirection = x.WindDirection,
                    WindSpeed = x.WindSpeed
                }).ToList();
                await _weatherForecastContext.WeatherForecast.AddRangeAsync(weatherForecasts);
            }

            await _weatherForecastContext.SaveChangesAsync();
            _logger.LogInformation("Seeding Finished");
        }
    }
}