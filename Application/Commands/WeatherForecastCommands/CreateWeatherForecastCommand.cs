using Application.Models;
using Application.Repositories;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Commands.WeatherForecastCommands
{
    public class CreateWeatherForecastCommand : ICreateWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<CreateWeatherForecastCommand> _logger;

        public CreateWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository, ILogger<CreateWeatherForecastCommand> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        public void Execute(WeatherForecastModel weatherForecastModel)
        {
            var weatherForecast = new WeatherForecast()
            {
                AirPressure = weatherForecastModel.AirPressure,
                Date = weatherForecastModel.Date,
                WeatherForecastId = weatherForecastModel.Id,
                LocationId = weatherForecastModel.LocationId,
                WeatherState = weatherForecastModel.WeatherState,
                WindDirection = weatherForecastModel.WindDirection,
                WindSpeed = weatherForecastModel.WindSpeed
            };
            _weatherForecastRepository.AddWeatherForecast(weatherForecast);
            _weatherForecastRepository.SaveChanges();
            _logger.LogInformation("Created weather forecast. Forecast id: {@id}", weatherForecastModel.Id);
        }
    }
}