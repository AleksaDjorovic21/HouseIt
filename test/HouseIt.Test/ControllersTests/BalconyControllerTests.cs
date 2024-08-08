using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HouseIt.Tests.Controllers;

public class BalconyControllerTests
{
    private readonly Mock<IBalconyRepository> _repositoryMock;
    private readonly BalconyController _controller;

    public BalconyControllerTests()
    {
        _repositoryMock = new Mock<IBalconyRepository>();
        _controller = new BalconyController(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllBalconies()
    {
        // Arrange
        var balconies = new List<Balcony>
            {
                new(BalconySize.Small, BalconyType.Covered),
                new(BalconySize.Medium, BalconyType.Open)
            };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(balconies);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Balcony>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnBalcony()
    {
        // Arrange
        var balcony = new Balcony(BalconySize.Large, BalconyType.Open);
        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(balcony);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Balcony>(actionResult.Value);
        Assert.Equal(balcony, returnValue);
    }

    [Fact]
    public async Task Create_ShouldAddBalcony()
    {
        // Arrange
        var balcony = new Balcony(BalconySize.Large, BalconyType.Open) { Id = 1 };

        // Act
        var result = await _controller.Create(balcony);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Balcony>(actionResult.Value);
        Assert.Equal(balcony, returnValue);
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Balcony>()), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnNoContent()
    {
        // Arrange
        var balcony = new Balcony(BalconySize.Large, BalconyType.Open) { Id = 1 };

        // Act
        var result = await _controller.Update(1, balcony);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Balcony>()), Times.Once);
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
