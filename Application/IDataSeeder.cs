using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Services.WeatherForecast;

namespace Application
{
    public interface IDataSeeder
    {
        void Seed(List<WeatherForecastModel> weatherForecasts);
    }
}