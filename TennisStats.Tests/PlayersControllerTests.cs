using Xunit;
using Moq;
using TennisStats.API.Controllers;
using TennisStats.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TennisStats.Domain.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace TennisStats.Tests.UnitTests
{
    public class PlayersControllerTests
    {
        [Fact]
        public async Task GetPlayers_ShouldReturnOkResult()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player { Id = 1, Firstname = "Roger", Lastname = "Federer" }
                });

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetPlayers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var players = Assert.IsType<List<Player>>(okResult.Value);
            players.Should().NotBeNullOrEmpty();
            players.Should().HaveCount(1);

            // Vérification du log
            mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task GetPlayerById_ShouldReturnNotFound_WhenPlayerDoesNotExist()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetPlayerByIdAsync(1))
                .ReturnsAsync((Player?)null);

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetPlayerById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);

            // Vérification du log
            mockLogger.Verify(logger => logger.LogWarning(It.IsAny<string>(), 1), Times.Once);
        }

        [Fact]
        public async Task GetPlayerById_ShouldReturnOkResult_WhenPlayerExists()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetPlayerByIdAsync(1))
                .ReturnsAsync(new Player
                {
                    Id = 1,
                    Firstname = "Roger",
                    Lastname = "Federer"
                });

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetPlayerById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var player = Assert.IsType<Player>(okResult.Value);
            player.Firstname.Should().Be("Roger");

            // Vérification du log
            mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>(), 1), Times.Once);
        }

        [Fact]
        public async Task GetCountryWithBestWinRatio_ShouldReturnOkResult()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetCountryWithBestWinRatioAsync())
                .ReturnsAsync("CH");

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetCountryWithBestWinRatio();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.Should().Be("CH");

            // Vérification du log
            mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetAverageBmi_ShouldReturnOkResult()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetAverageBmiAsync())
                .ReturnsAsync(24.22);

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetAverageBmi();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.Should().Be(24.22);

            // Vérification du log
            mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetMedianHeight_ShouldReturnOkResult()
        {
            // Arrange
            var mockService = new Mock<IPlayerService>();
            var mockLogger = new Mock<ILogger<PlayersController>>(); // Mock du logger

            mockService.Setup(service => service.GetMedianHeightAsync())
                .ReturnsAsync(180);

            var controller = new PlayersController(mockService.Object, mockLogger.Object);

            // Act
            var result = await controller.GetMedianHeight();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.Should().Be(180);

            // Vérification du log
            mockLogger.Verify(logger => logger.LogInformation(It.IsAny<string>()), Times.Once);
        }
    }
}
