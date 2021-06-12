using Application.Models;

namespace Application.Queries
{
    public interface IGetWeatherForecastQuery
    {
        WeatherForecastModel Execute(long id);
    }
}