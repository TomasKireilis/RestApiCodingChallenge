using Infrastructure.Services.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateWeatherForecastCommand : ICreateWeatherForecastCommand
    {
        public async Task Execute(WeatherForecastModel weatherForecastModel)
        {
        }
    }
}