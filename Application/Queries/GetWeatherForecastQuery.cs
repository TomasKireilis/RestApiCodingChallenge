using Application.Models;
using Application.Repositories;

namespace Application.Queries
{
    public class GetWeatherForecastQuery : IGetWeatherForecastQuery
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetWeatherForecastQuery(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public WeatherForecastModel Execute(long id)
        {
            var weatherForecast = _weatherForecastRepository.GetWeatherForecast(id);
            return new WeatherForecastModel(weatherForecast.LocationId)
            {
                AirPressure = weatherForecast.AirPressure,
                Date = weatherForecast.Date,
                Id = weatherForecast.Id,
                LocationId = weatherForecast.LocationId,
                WeatherState = weatherForecast.WeatherState,
                WindDirection = weatherForecast.WindDirection,
                WindSpeed = weatherForecast.WindSpeed
            };
        }
    }
}