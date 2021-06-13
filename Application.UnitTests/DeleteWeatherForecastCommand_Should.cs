using Application.Commands.WeatherForecastCommands;
using Application.Models;
using Application.Repositories;
using Domain;
using Moq;
using System;
using Xunit;

namespace Application.UnitTests
{
    public class DeleteWeatherForecastCommand_Should

    {
        [Fact]
        public void Send_CorrectData_Repository()
        {
            //setup
            var id = 50;
            var repositoryMock = new Mock<IWeatherForecastRepository>();

            var deleteWeatherForecastCommand = new DeleteWeatherForecastCommand(repositoryMock.Object);

            //act
            deleteWeatherForecastCommand.Execute(id);

            //Assert
            repositoryMock.Verify(x => x.DeleteWeatherForecast(It.Is<long>(y =>
               y == id
            )), Times.Once);

            repositoryMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}