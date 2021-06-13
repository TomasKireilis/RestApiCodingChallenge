using Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public interface IDataSeeder
    {
        Task<bool> AlreadySeeded();

        Task Seed(List<WeatherForecastModel> weatherForecastModels);
    }
}