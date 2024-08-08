using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HouseIt.Tests.Controllers;

public class ToiletControllerTests
{
    private readonly Mock<IToiletRepository> _repositoryMock;
    private readonly ToiletController _controller;

    public ToiletControllerTests()
    {
        _repositoryMock = new Mock<IToiletRepository>();
        _controller = new ToiletController(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllToilets()
    {
        // Arrange
        var toilets = new List<Toilet>
            {
                new() { ToiletType = ToiletTypes.Shower, Id = 1 },
                new() { ToiletType = ToiletTypes.Bathtub, Id = 2 }
            };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(toilets);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Toilet>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnToilet()
    {
        // Arrange
        var toilet = new Toilet { ToiletType = ToiletTypes.Shower, Id = 1 };
        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(toilet);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Toilet>(actionResult.Value);
        Assert.Equal(toilet, returnValue);
    }

    [Fact]
    public async Task Create_ShouldAddToilet()
    {
        // Arrange
        var toilet = new Toilet { ToiletType = ToiletTypes.Shower, Id = 1 };

        // Act
        var result = await _controller.Create(toilet);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Toilet>(actionResult.Value);
        Assert.Equal(toilet, returnValue);
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Toilet>()), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnNoContent()
    {
        // Arrange
        var toilet = new Toilet { ToiletType = ToiletTypes.Shower, Id = 1 };

        // Act
        var result = await _controller.Update(1, toilet);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Toilet>()), Times.Once);
    }

    [Fact]
    public async Task Delete_ShouldReturnNoContent()
    {
        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _repositoryMock.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
    }
}
