using Application.Repositories;
using Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Persistence
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastContext _weatherForecastContext;
        private readonly ILogger<WeatherForecastRepository> _logger;

        public WeatherForecastRepository(WeatherForecastContext weatherForecastContext, ILogger<WeatherForecastRepository> logger)
        {
            _weatherForecastContext = weatherForecastContext;
            _logger = logger;
        }

        public void AddWeatherForecast(WeatherForecast weatherForecast)
        {
            try
            {
                UpdateWeatherForecast(weatherForecast);
                _logger.LogInformation("Found existing weather forecast. Updating existing record. Forecast id: {@id}", weatherForecast.WeatherForecastId);
            }
            catch (ArgumentException e)
            {
                _weatherForecastContext.WeatherForecast.AddAsync(weatherForecast);
                _logger.LogInformation("Adding new weather forecast to repository. Forecast id: {@id}", weatherForecast.WeatherForecastId);
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
                _logger.LogInformation("Updating weather forecast in repository. Forecast id: {@id}", weatherForecast.WeatherForecastId);
                return;
            }
            _logger.LogInformation("Can not update weather forecast. Weather forecast was not found. Forecast id: {@id}", weatherForecast.WeatherForecastId);
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
                _logger.LogInformation("Deleting weather forecast in repository. Forecast id: {@id}", id);
                _weatherForecastContext.WeatherForecast.Remove(trackedWeatherForecast);
                return;
            }
            _logger.LogInformation("No existing record found for deletion. Forecast id: {@id}", id);
        }

        public void SaveChanges()
        {
            try
            {
                _weatherForecastContext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError("Error while saving changes to database. {@error}", e.Message);
                throw;
            }
        }
    }
}