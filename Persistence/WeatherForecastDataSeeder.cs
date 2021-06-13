using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;

namespace Persistence
{
    public class WeatherForecastDataSeeder : IDataSeeder
    {
        private readonly WeatherForecastContext _weatherForecastContext;

        public WeatherForecastDataSeeder(WeatherForecastContext weatherForecastContext)
        {
            _weatherForecastContext = weatherForecastContext;
        }

        public async Task<bool> AlreadySeeded()
        {
            await _weatherForecastContext.Database.EnsureCreatedAsync();
            return _weatherForecastContext.WeatherForecast.Any();
        }

        public async Task Seed(List<WeatherForecastModel> weatherForecastModels)
        {
            Console.WriteLine("Seeding...");
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
        }
    }
}