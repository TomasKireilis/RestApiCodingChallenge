using Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IWeatherForecastService
    {
        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        Task<WeatherForecastModel> GetForecastInRegion(int locationId, DateTime time);

        Task<List<WeatherForecastModel>> GetForecastsInRegion(List<int> locationIds, DateTime time);
    }
}