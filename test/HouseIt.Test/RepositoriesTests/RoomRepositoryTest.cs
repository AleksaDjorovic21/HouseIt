using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class RoomRepositoryTest : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddRoom()
    {
        // Arrange
        using var context = new HouseItDbContext(_options);
        var repository = new RoomRepository(context);
        var room = new Room { Id = 1, RoomType = RoomTypes.SittingRoom, Sqrm = 20, Color = ColorPalette.White };

        // Act
        await repository.AddAsync(room);
        var addedRoom = await context.Rooms.FindAsync(1);

        // Assert
        Assert.NotNull(addedRoom);
        Assert.Equal(RoomTypes.SittingRoom, addedRoom.RoomType);
        Assert.Equal(20, addedRoom.Sqrm);
        Assert.Equal(ColorPalette.White, addedRoom.Color);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllRooms()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Rooms.AddRange(new List<Room>
                {
                    new() { Id = 1, RoomType = RoomTypes.Bedroom, Sqrm = 15, Color = ColorPalette.Blue },
                    new() { Id = 2, RoomType = RoomTypes.SittingRoom, Sqrm = 10, Color = ColorPalette.Green }
                });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new RoomRepository(context);
            var rooms = await repository.GetAllAsync();

            Assert.Equal(2, rooms.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnRoom()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Rooms.Add(new Room { Id = 1, RoomType = RoomTypes.Bedroom, Sqrm = 15, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new RoomRepository(context);
            var room = await repository.GetByIdAsync(1);

            Assert.NotNull(room);
            Assert.Equal(RoomTypes.Bedroom, room.RoomType);
            Assert.Equal(15, room.Sqrm);
            Assert.Equal(ColorPalette.Blue, room.Color);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateRoom()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Rooms.Add(new Room { Id = 1, RoomType = RoomTypes.Bedroom, Sqrm = 15, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new RoomRepository(context);
            var updatedRoom = new Room { Id = 1, RoomType = RoomTypes.SittingRoom, Sqrm = 20, Color = ColorPalette.White };

            await repository.UpdateAsync(updatedRoom);
            var room = await context.Rooms.FindAsync(1);

            Assert.NotNull(room);
            Assert.Equal(RoomTypes.SittingRoom, room.RoomType);
            Assert.Equal(20, room.Sqrm);
            Assert.Equal(ColorPalette.White, room.Color);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteRoom()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Rooms.Add(new Room { Id = 1, RoomType = RoomTypes.Bedroom, Sqrm = 15, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new RoomRepository(context);
            await repository.DeleteAsync(1);
            var room = await context.Rooms.FindAsync(1);

            Assert.Null(room);
        }
    }
}

