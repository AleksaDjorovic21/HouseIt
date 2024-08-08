using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HouseIt.Tests.Controllers;

public class RoomControllerTests
{
    private readonly Mock<IRoomRepository> _repositoryMock;
    private readonly RoomController _controller;

    public RoomControllerTests()
    {
        _repositoryMock = new Mock<IRoomRepository>();
        _controller = new RoomController(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllRooms()
    {
        // Arrange
        var room1 = new Room { RoomType = RoomTypes.Bedroom, Sqrm = 25, Color = ColorPalette.White };
        var room2 = new Room { RoomType = RoomTypes.Bedroom, Sqrm = 15, Color = ColorPalette.Blue };

        var rooms = new List<Room> { room1, room2 };

        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(rooms);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<Room>>(actionResult.Value);
        Assert.Equal(2, returnValue.Count);
    }

    [Fact]
    public async Task GetById_ShouldReturnRoom()
    {
        // Arrange
        var room = new Room { RoomType = RoomTypes.Bedroom, Sqrm = 25, Color = ColorPalette.White };
        _repositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(room);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<Room>(actionResult.Value);
        Assert.Equal(room, returnValue);
    }

    [Fact]
    public async Task Create_ShouldAddRoom()
    {
        // Arrange
        var room = new Room { RoomType = RoomTypes.Bedroom, Sqrm = 25, Color = ColorPalette.White, Id = 1 };

        // Act
        var result = await _controller.Create(room);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<Room>(actionResult.Value);
        Assert.Equal(room, returnValue);
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Room>()), Times.Once);
    }

    [Fact]
    public async Task Update_ShouldReturnNoContent()
    {
        // Arrange
        var room = new Room { RoomType = RoomTypes.Bedroom, Sqrm = 25, Color = ColorPalette.White, Id = 1 };

        // Act
        var result = await _controller.Update(1, room);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Room>()), Times.Once);
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
