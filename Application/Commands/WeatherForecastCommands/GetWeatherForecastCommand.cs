using System.Threading.Tasks;
using Application.Models;
using Application.Repositories;
using Domain;

namespace Application.Commands.WeatherForecastCommands
{
    public class GetWeatherForecastCommand : IGetWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task Execute(long id)
        {
            _weatherForecastRepository.GetWeatherForecast(id);
        }
    }
}