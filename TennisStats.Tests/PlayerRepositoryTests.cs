using Xunit;
using Moq;
using TennisStats.Domain.Entities;
using TennisStats.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;

namespace TennisStats.Tests.UnitTests
{
    public class PlayerRepositoryTests
    {
        [Fact]
        public async Task GetAllPlayersAsync_ShouldReturnPlayers()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetAllPlayersAsync())
                .ReturnsAsync(new List<Player>
                {
                    new Player { Id = 1, Firstname = "Roger", Lastname = "Federer" },
                    new Player { Id = 2, Firstname = "Rafael", Lastname = "Nadal" }
                });

            // Act
            var result = await mockRepository.Object.GetAllPlayersAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result[0].Firstname.Should().Be("Roger");
        }

        [Fact]
        public async Task GetPlayerByIdAsync_ShouldReturnPlayer()
        {
            // Arrange
            var mockRepository = new Mock<IPlayerRepository>();
            mockRepository.Setup(repo => repo.GetPlayerByIdAsync(1))
                .ReturnsAsync(new Player { Id = 1, Firstname = "Roger", Lastname = "Federer" });

            // Act
            var result = await mockRepository.Object.GetPlayerByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Firstname.Should().Be("Roger");
        }
    }
}
