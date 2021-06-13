using Application.Commands.WeatherForecastCommands;
using Application.Models;
using Application.Repositories;
using Domain;
using Moq;
using System;
using Application.Queries;
using Xunit;

namespace Application.UnitTests
{
    public class GetWeatherForecastQuery_Should

    {
        [Fact]
        public void Send_CorrectData_Repository()
        {
            //setup
            var id = 50;

            var forecastDomainModel = new WeatherForecast()
            {
                AirPressure = 10,
                Date = DateTime.Today,
                WeatherForecastId = id,
                LocationId = 10,
                WeatherState = "Mild",
                WindDirection = 40,
                WindSpeed = 15,
            };

            var forecastApplicationModel = new WeatherForecastModel()
            {
                AirPressure = 10,
                Date = DateTime.Today,
                Id = id,
                LocationId = 10,
                WeatherState = "Mild",
                WindDirection = 40,
                WindSpeed = 15,
            };

            var repositoryMock = new Mock<IWeatherForecastRepository>();
            repositoryMock.Setup(x => x.GetWeatherForecast(id)).Returns(forecastDomainModel);

            var getWeatherForecastQuery = new GetWeatherForecastQuery(repositoryMock.Object);

            //act
            var response = getWeatherForecastQuery.Execute(id);

            //Assert
            Assert.True(response.AirPressure == forecastApplicationModel.AirPressure &&
                        response.Date == forecastApplicationModel.Date &&
                        response.Id == forecastApplicationModel.Id &&
                        response.LocationId == forecastApplicationModel.LocationId &&
                        response.WeatherState == forecastApplicationModel.WeatherState &&
                        response.WindDirection == forecastApplicationModel.WindDirection &&
                        response.WindSpeed == forecastApplicationModel.WindSpeed);
        }
    }
}