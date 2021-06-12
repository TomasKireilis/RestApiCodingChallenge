using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IWeatherForecastService
    {
        /// <summary>
        /// locationId = woeid = Where On Earth ID
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        Task<List<WeatherForecast>> GetForecastsInRegion(int locationId);

        Task<List<WeatherForecast>> GetForecastsInRegion(List<int> locationIds);
    }
}