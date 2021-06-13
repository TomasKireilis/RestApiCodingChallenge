namespace Application.Commands.WeatherForecastCommands
{
    public interface IDeleteWeatherForecastCommand
    {
        void Execute(long id);
    }
}