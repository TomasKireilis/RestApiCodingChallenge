using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Application
{
    public interface IDataSeeder
    {
        Task<bool> AlreadySeeded();

        Task Seed(List<WeatherForecastModel> weatherForecastModels);
    }
}