using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.WeatherForecast
{
    public interface IWeatherForecastService
    {
        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        Task<List<WeatherForecastDto>> GetForecastsInRegion(int locationId, DateTime time);

        Task<List<WeatherForecastDto>> GetForecastsInRegion(List<int> locationIds, DateTime time);
    }
}