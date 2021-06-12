using System.Threading.Tasks;
using Application.Models;

namespace Application.Commands.WeatherForecastCommands
{
    public interface ICreateWeatherForecastCommand
    {
        Task Execute(WeatherForecastModel weatherForecastModel);
    }

    public interface IUpdateWeatherForecastCommand
    {
        Task Execute(WeatherForecastModel weatherForecastModel);
    }

    public interface IDeleteWeatherForecastCommand
    {
        Task Execute(long id);
    }

    public interface IGetWeatherForecastCommand
    {
        Task Execute(long id);
    }
}