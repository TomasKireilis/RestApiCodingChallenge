using Application.Models;

namespace Application.Commands.WeatherForecastCommands
{
    public interface ICreateWeatherForecastCommand
    {
        void Execute(WeatherForecastModel weatherForecastModel);
    }
}