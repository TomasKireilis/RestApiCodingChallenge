using Application.Commands.WeatherForecastCommands;
using Application.Models;
using Application.Repositories;
using Domain;
using Moq;
using System;
using Xunit;

namespace Application.UnitTests
{
    public class UpdateWeatherForecastCommand_Should

    {
        [Theory]
        [InlineData(1, "2021-06-12T21:32:03.076320Z", 1, 90, "warm", 96.1f, 96f)]
        [InlineData(10, "2021-06-12T21:32:03.076320Z", 9999999, 90, "", 96.1f, 96f)]
        [InlineData(0, "2021-06-12T21:32:03.076320Z", 0, 0, "cold", 96.1f, 0f)]
        [InlineData(12.5, "2021-06-12T21:32:03.076320Z", 1, 90, null, 96.1f, -9f)]
        public void Send_CorrectData_Repository(float airPressure, string dateString, long id, int locationId, string weatherState, float windDirection, float windSpeed)
        {
            //setup
            var date = DateTime.Parse(dateString);

            var forecastApplicationModel = new WeatherForecastModel()
            {
                AirPressure = airPressure,
                Date = date,
                Id = id,
                LocationId = locationId,
                WeatherState = weatherState,
                WindDirection = windDirection,
                WindSpeed = windSpeed,
            };

            var repository = new Mock<IWeatherForecastRepository>();

            var updateWeatherForecastCommand = new UpdateWeatherForecastCommand(repository.Object);

            //act
            updateWeatherForecastCommand.Execute(forecastApplicationModel);

            //Assert
            repository.Verify(x => x.UpdateWeatherForecast(It.Is<WeatherForecast>(y =>
              y.AirPressure == airPressure &&
              y.Date == date &&
              y.WeatherForecastId == id &&
              y.LocationId == locationId &&
              y.WeatherState == weatherState &&
              y.WindDirection == windDirection &&
              y.WindSpeed == windSpeed
                )), Times.Once);

            repository.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}