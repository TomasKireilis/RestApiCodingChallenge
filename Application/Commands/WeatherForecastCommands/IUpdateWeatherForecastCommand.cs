using Application.Models;

namespace Application.Commands.WeatherForecastCommands
{
    public interface IUpdateWeatherForecastCommand
    {
        void Execute(WeatherForecastModel weatherForecastModel);
    }
}