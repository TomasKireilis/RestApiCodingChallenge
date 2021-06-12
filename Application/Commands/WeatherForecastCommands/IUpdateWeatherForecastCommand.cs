using System.Threading.Tasks;
using Application.Models;

namespace Application.Commands.WeatherForecastCommands
{
    public interface IUpdateWeatherForecastCommand
    {
        Task Execute(WeatherForecastModel weatherForecastModel);
    }
}