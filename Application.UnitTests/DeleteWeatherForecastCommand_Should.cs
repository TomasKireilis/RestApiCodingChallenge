using Application.Commands.WeatherForecastCommands;
using Application.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Application.UnitTests
{
    public class DeleteWeatherForecastCommand_Should

    {
        [Fact]
        public void Delete_CorrectData_Repository()
        {
            //setup
            var id = 50;
            var repositoryMock = new Mock<IWeatherForecastRepository>();
            var loggerMock = new Mock<ILogger<DeleteWeatherForecastCommand>>();

            var deleteWeatherForecastCommand = new DeleteWeatherForecastCommand(repositoryMock.Object, loggerMock.Object);

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