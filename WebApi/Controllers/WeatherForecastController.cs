using Application.Commands.WeatherForecastCommands;
using Application.Models;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ICreateWeatherForecastCommand _createWeatherForecastCommand;
        private readonly IUpdateWeatherForecastCommand _updateWeatherForecastCommand;
        private readonly IDeleteWeatherForecastCommand _deleteWeatherForecastCommand;
        private readonly IGetWeatherForecastQuery _getWeatherForecastQuery;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ICreateWeatherForecastCommand createWeatherForecastCommand,
            IUpdateWeatherForecastCommand updateWeatherForecastCommand,
            IDeleteWeatherForecastCommand deleteWeatherForecastCommand,
            IGetWeatherForecastQuery getWeatherForecastQuery)
        {
            _logger = logger;
            _createWeatherForecastCommand = createWeatherForecastCommand;
            _updateWeatherForecastCommand = updateWeatherForecastCommand;
            _deleteWeatherForecastCommand = deleteWeatherForecastCommand;
            _getWeatherForecastQuery = getWeatherForecastQuery;
        }

        [HttpGet("{id}")]
        public WeatherForecastModel Get(long id)
        {
            return _getWeatherForecastQuery.Execute(id);
        }

        [HttpPost]
        public void Post([FromBody] WeatherForecastModel weatherForecast)
        {
            _createWeatherForecastCommand.Execute(weatherForecast);
        }

        [HttpPut]
        public void Put([FromBody] WeatherForecastModel weatherForecast)
        {
            _updateWeatherForecastCommand.Execute(weatherForecast);
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _deleteWeatherForecastCommand.Execute(id);
        }
    }
}