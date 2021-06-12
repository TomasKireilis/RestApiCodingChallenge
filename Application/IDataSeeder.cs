using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IDataSeeder
    {
        Task Seed(List<WeatherForecastModel> weatherForecastModels);
    }
}