using System.Threading.Tasks;
using Application.Models;
using Application.Repositories;
using Domain;

namespace Application.Commands.WeatherForecastCommands
{
    public class UpdateWeatherForecastCommand : IUpdateWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public UpdateWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
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
        }
    }
}