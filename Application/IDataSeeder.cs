using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application
{
    public interface IDataSeeder
    {
        Task Seed(List<WeatherForecastModel> weatherForecastModels);
    }
}