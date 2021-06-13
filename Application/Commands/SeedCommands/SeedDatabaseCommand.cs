using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Services;

namespace Application.Commands.SeedCommands
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
            if (!await _seeder.AlreadySeeded())
            {
                var weatherForecasts = await _weatherForecastService.GetForecastsInRegion(_locationsId, DateTime.Now);

                await _seeder.Seed(weatherForecasts);
                return;
            }
            Console.WriteLine("Seeding was skipped. Existing data found");
        }
    }
}