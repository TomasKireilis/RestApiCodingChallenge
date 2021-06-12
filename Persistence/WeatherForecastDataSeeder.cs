using System;
using System.Collections.Generic;
using System.Linq;

using Application;
using Domain;
using Infrastructure.Services.WeatherForecast;

namespace Persistence
{
    public class WeatherForecastDataSeeder : IDataSeeder
    {
        private readonly WeatherForecastContext _weatherForecastContext;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly List<int> _locationIds = new List<int>() { 44501, 12451 };

        public WeatherForecastDataSeeder(WeatherForecastContext weatherForecastContext, IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            _weatherForecastContext = weatherForecastContext;
        }

        public void Seed(List<WeatherForecastModel> weatherForecastModels)
        {
            Console.WriteLine("Creating db...");
            _weatherForecastContext.Database.EnsureCreated();
            Console.WriteLine("Seeding...");
            if (_weatherForecastContext.WeatherForecast.Any())
            {
                var weatherForecasts = weatherForecastModels.Select(x => new WeatherForecast(x.LocationId)
                {
                    AirPressure = x.AirPressure,
                    ApplicableDate = x.ApplicableDate,
                    Id = x.Id,
                    LocationId = x.LocationId,
                    WeatherStateAbbr = x.WeatherStateAbbr,
                    WeatherStateName = x.WeatherStateName,
                    WindDirection = x.WindDirection,
                    WindSpeed = x.WindSpeed
                }).ToList();
                _weatherForecastContext.WeatherForecast.AddRangeAsync(weatherForecasts);
            }
        }
    }
}