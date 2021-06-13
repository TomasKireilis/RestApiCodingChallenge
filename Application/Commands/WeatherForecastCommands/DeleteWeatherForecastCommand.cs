using System.Threading.Tasks;
using Application.Models;
using Application.Repositories;
using Domain;

namespace Application.Commands.WeatherForecastCommands
{
    public class DeleteWeatherForecastCommand : IDeleteWeatherForecastCommand
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public DeleteWeatherForecastCommand(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public void Execute(long id)
        {
            _weatherForecastRepository.DeleteWeatherForecast(id);
            _weatherForecastRepository.SaveChanges();
        }
    }
}