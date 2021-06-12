using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICreateWeatherForecastCommand
    {
        Task Execute(WeatherForecastModel weatherForecastModel);
    }
}