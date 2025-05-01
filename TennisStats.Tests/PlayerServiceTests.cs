using Xunit;
using Moq;
using TennisStats.Application.Services;
using TennisStats.Domain.Entities;
using TennisStats.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TennisStats.Domain.Interfaces;

namespace TennisStats.Tests.UnitTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public async Task GetAllPlayersAsync_ShouldReturnPlayers()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player { Id = 1, Firstname = "Roger", Lastname = "Federer" }
                });

            var service = new PlayerService(mockRepository.Object);

            // Act
            var result = await service.GetAllPlayersAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(1);
            result[0].Firstname.Should().Be("Roger");
        }

        [Fact]
        public async Task GetPlayerByIdAsync_ShouldReturnPlayer()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetPlayerByIdAsync(1))
                .ReturnsAsync(new Player
                {
                    Id = 1,
                    Firstname = "Roger",
                    Lastname = "Federer"
                });

            var service = new PlayerService(mockRepository.Object);

            // Act
            var result = await service.GetPlayerByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Firstname.Should().Be("Roger");
        }

        [Fact]
        public async Task GetCountryWithBestWinRatioAsync_ShouldReturnCountry()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player
                    {
                        Id = 1,
                        Country = new Country { Code = "CH" },
                        Data = new PlayerData { Last = new List<int> { 1, 1, 0 } }
                    },
                    new Player
                    {
                        Id = 2,
                        Country = new Country { Code = "FR" },
                        Data = new PlayerData { Last = new List<int> { 0, 0, 1 } }
                    }
                });

            var service = new PlayerService(mockRepository.Object);

            // Act
            var result = await service.GetCountryWithBestWinRatioAsync();

            // Assert
            result.Should().Be("CH");
        }

        [Fact]
        public async Task GetAverageBmiAsync_ShouldReturnAverageBmi()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player
                    {
                        Data = new PlayerData { Weight = 80, Height = 180 }
                    },
                    new Player
                    {
                        Data = new PlayerData { Weight = 70, Height = 170 }
                    }
                });

            var service = new PlayerService(mockRepository.Object);

            // Act
            var result = await service.GetAverageBmiAsync();

            // Assert
            result.Should().BeApproximately(24.22, 0.01); // IMC moyen calculé
        }

        [Fact]
        public async Task GetMedianHeightAsync_ShouldReturnMedianHeight()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player { Data = new PlayerData { Height = 180 } },
                    new Player { Data = new PlayerData { Height = 170 } },
                    new Player { Data = new PlayerData { Height = 190 } }
                });

            var service = new PlayerService(mockRepository.Object);

            // Act
            var result = await service.GetMedianHeightAsync();

            // Assert
            result.Should().Be(180); // Médiane de [170, 180, 190]
        }
    }
}
