using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Application.Commands;
using Application.Commands.WeatherForecastCommands;
using Application.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;

        private readonly ICreateWeatherForecastCommand _createWeatherForecastCommand;

        public DataController(ILogger<DataController> logger, ICreateWeatherForecastCommand createWeatherForecastCommand)
        {
            _logger = logger;
            _createWeatherForecastCommand = createWeatherForecastCommand;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastDto> Get()
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody] WeatherForecastModel weatherForecastDto)
        {
            _createWeatherForecastCommand.Execute(weatherForecastDto);
        }

        [HttpPut]
        public IEnumerable<WeatherForecastDto> Put()
        {
            return null;
        }

        [HttpDelete]
        public IEnumerable<WeatherForecastDto> Delete()
        {
            return null;
        }
    }
}