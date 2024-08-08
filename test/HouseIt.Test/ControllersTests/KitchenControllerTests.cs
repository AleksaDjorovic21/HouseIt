using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HouseIt.Tests.Controllers;

public class KitchenControllerTests
{
    private readonly Mock<IKitchenRepository> _repositoryMock;
    private readonly KitchenController _controller;

    public KitchenControllerTests()
    {
        _repositoryMock = new Mock<IKitchenRepository>();
        _controller = new KitchenController(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllKitchens()
    {
        // Arrange
        var kitchens = new List<Kitchen>
            {
                new() { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White },
                new() { Id = 2, HasDiningArea = false, Sqrm = 15, Color = ColorPalette.Blue }
            };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(kitchens);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Kitchen>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnKitchen()
    {
        // Arrange
        var kitchen = new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White };
        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(kitchen);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Kitchen>(actionResult.Value);
        Assert.Equal(kitchen, returnValue);
    }

    [Fact]
    public async Task Create_ShouldAddKitchen()
    {
        // Arrange
        var kitchen = new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White };

        // Act
        var result = await _controller.Create(kitchen);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Kitchen>(actionResult.Value);
        Assert.Equal(kitchen, returnValue);
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Kitchen>()), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnNoContent()
    {
        // Arrange
        var kitchen = new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White };

        // Act
        var result = await _controller.Update(1, kitchen);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Kitchen>()), Times.Once);
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
