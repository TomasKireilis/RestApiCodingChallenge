﻿using System.Threading.Tasks;
using Application.Models;

namespace Application.Commands.WeatherForecastCommands
{
    public interface ICreateWeatherForecastCommand
    {
        Task Execute(WeatherForecastModel weatherForecastModel);
    }
}