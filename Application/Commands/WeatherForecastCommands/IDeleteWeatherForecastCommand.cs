using System.Threading.Tasks;

namespace Application.Commands.WeatherForecastCommands
{
    public interface IDeleteWeatherForecastCommand
    {
        void Execute(long id);
    }
}