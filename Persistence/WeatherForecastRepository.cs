using Application.Repositories;
using Domain;
using System;
using System.Linq;

namespace Persistence
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastContext _weatherForecastContext;

        public WeatherForecastRepository(WeatherForecastContext weatherForecastContext)
        {
            _weatherForecastContext = weatherForecastContext;
        }

        public void AddWeatherForecast(WeatherForecast weatherForecast)
        {
            try
            {
                UpdateWeatherForecast(weatherForecast);
            }
            catch (ArgumentException e)
            {
                _weatherForecastContext.WeatherForecast.AddAsync(weatherForecast);
            }
        }

        public void UpdateWeatherForecast(WeatherForecast weatherForecast)
        {
            var trackedWeatherForecast = _weatherForecastContext.WeatherForecast.SingleOrDefault(b => b.WeatherForecastId == weatherForecast.WeatherForecastId);
            if (trackedWeatherForecast != null)
            {
                trackedWeatherForecast.LocationId = weatherForecast.LocationId;
                trackedWeatherForecast.AirPressure = weatherForecast.AirPressure;
                trackedWeatherForecast.Date = weatherForecast.Date;
                trackedWeatherForecast.WeatherState = weatherForecast.WeatherState;
                trackedWeatherForecast.WindDirection = weatherForecast.WindDirection;
                trackedWeatherForecast.WindSpeed = weatherForecast.WindSpeed;

                return;
            }
            throw new ArgumentException("Weather forecast was not found");
        }

        public WeatherForecast GetWeatherForecast(long id)
        {
            return _weatherForecastContext.WeatherForecast.FirstOrDefault(x => x.WeatherForecastId == id);
        }

        public void DeleteWeatherForecast(long id)
        {
            var trackedWeatherForecast = _weatherForecastContext.WeatherForecast.SingleOrDefault(b => b.WeatherForecastId == id);
            if (trackedWeatherForecast != null)
            {
                _weatherForecastContext.WeatherForecast.Remove(trackedWeatherForecast);
            }
        }

        public void SaveChanges()
        {
            try
            {
                _weatherForecastContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}