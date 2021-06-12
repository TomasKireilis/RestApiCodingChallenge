using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class WeatherForecastDataSeeder : IDataSeeder
    {
        private readonly WeatherForecastContext _weatherForecastContext;

        public WeatherForecastDataSeeder(WeatherForecastContext weatherForecastContext)
        {
            _weatherForecastContext = weatherForecastContext;
        }

        public async Task Seed(List<WeatherForecastModel> weatherForecastModels)
        {
            Console.WriteLine("Creating db...");
            _weatherForecastContext.Database.EnsureCreated();
            Console.WriteLine("Seeding...");
            if (!_weatherForecastContext.WeatherForecast.Any())
            {
                var weatherForecasts = weatherForecastModels.Select(x => new WeatherForecast()
                {
                    AirPressure = x.AirPressure,
                    Date = x.Date,
                    WeatherForecastId = x.Id,
                    LocationId = x.LocationId,
                    WindDirection = x.WindDirection,
                    WindSpeed = x.WindSpeed
                }).ToList();
                await _weatherForecastContext.WeatherForecast.AddRangeAsync(weatherForecasts);
            }

            await _weatherForecastContext.SaveChangesAsync();
        }
    }
}