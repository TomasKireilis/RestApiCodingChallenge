using Domain;

namespace Application.Repositories
{
    public interface IWeatherForecastRepository
    {
        void AddWeatherForecast(WeatherForecast weatherForecast);

        void UpdateWeatherForecast(WeatherForecast weatherForecast);

        WeatherForecast GetWeatherForecast(long id);

        void DeleteWeatherForecast(long id);

        void SaveChanges();
    }
}