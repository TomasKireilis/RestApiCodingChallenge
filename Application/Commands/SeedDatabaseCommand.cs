using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services.WeatherForecast;

namespace Application.Commands
{
    public class SeedDatabaseCommand : ISeedDatabaseCommand
    {
        private readonly IDataSeeder _seeder;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly List<int> _locationsId = new List<int>() { 44418, 2487956 };

        public SeedDatabaseCommand(IDataSeeder seeder, IWeatherForecastService weatherForecastService)
        {
            _seeder = seeder;
            _weatherForecastService = weatherForecastService;
        }

        public async Task Execute()
        {
            var weatherForecasts = await _weatherForecastService.GetForecastsInRegion(_locationsId, DateTime.Now);
            var weatherForecastModels = weatherForecasts.Select(x => new WeatherForecastModel(x.LocationId)
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

            _seeder.Seed(weatherForecastModels);
        }
    }
}