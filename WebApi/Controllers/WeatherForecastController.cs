using System;
using Application.Commands.WeatherForecastCommands;
using Application.Models;
using Application.Queries;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<WeatherForecastModel> GetWeatherForecast(long id)
        {
            _logger.LogInformation("Get WeatherForecast api called id {@id}", id);

            var response = _getWeatherForecastQuery.Execute(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult PostWeatherForecast([FromBody] WeatherForecastModel weatherForecast)
        {
            _logger.LogInformation("Post WeatherForecast api called id {@id}", weatherForecast.Id);
            _createWeatherForecastCommand.Execute(weatherForecast);
            return Ok();
        }

        [HttpPut]
        public ActionResult PutWeatherForecast([FromBody] WeatherForecastModel weatherForecast)
        {
            _logger.LogInformation("Put WeatherForecast api called id {@id}", weatherForecast.Id);
            _updateWeatherForecastCommand.Execute(weatherForecast);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteWeatherForecast(long id)
        {
            _logger.LogInformation("Delete WeatherForecast api called id {@id}", id);
            _deleteWeatherForecastCommand.Execute(id);
            return Ok();
        }
    }
}