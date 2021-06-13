using Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.Commands.SeedCommands
{
    public class SeedDatabaseCommand : ISeedDatabaseCommand
    {
        private readonly IDataSeeder _seeder;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ILogger<SeedDatabaseCommand> _logger;
        private readonly List<int> _locationsId = new List<int>() { 44418, 2487956 };

        public SeedDatabaseCommand(IDataSeeder seeder, IWeatherForecastService weatherForecastService, ILogger<SeedDatabaseCommand> logger)
        {
            _seeder = seeder;
            _weatherForecastService = weatherForecastService;
            _logger = logger;
        }

        public async Task Execute()
        {
            if (!await _seeder.AlreadySeeded())
            {
                var weatherForecasts = await _weatherForecastService.GetForecastsInRegion(_locationsId, DateTime.Now);

                await _seeder.Seed(weatherForecasts);
                return;
            }
            _logger.LogInformation("Seeding skipped. Existing data found");
        }
    }
}