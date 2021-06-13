using Application.Models;
using Application.Repositories;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Commands.WeatherForecastCommands
{
    public class UpdateWeatherForecastCommand : IUpdateWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<UpdateWeatherForecastCommand> _logger;

        public UpdateWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository, ILogger<UpdateWeatherForecastCommand> logger)
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
            _weatherForecastRepository.UpdateWeatherForecast(weatherForecast);
            _weatherForecastRepository.SaveChanges();
            _logger.LogInformation("Updated weather forecast. Forecast id: {@id}", weatherForecast.WeatherForecastId);
        }
    }
}