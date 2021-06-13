using Application.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Commands.WeatherForecastCommands
{
    public class DeleteWeatherForecastCommand : IDeleteWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<DeleteWeatherForecastCommand> _logger;

        public DeleteWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository, ILogger<DeleteWeatherForecastCommand> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        public void Execute(long id)
        {
            _weatherForecastRepository.DeleteWeatherForecast(id);
            _weatherForecastRepository.SaveChanges();
            _logger.LogInformation("Deleted weather forecast. Forecast id: {@id}", id);
        }
    }
}