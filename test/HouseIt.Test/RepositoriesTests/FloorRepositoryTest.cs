using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class FloorRepositoryTest : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddFloor()
    {
        // Arrange
        using var context = new HouseItDbContext(_options);
        var repository = new FloorRepository(context);

        var designRequest = new DesignRequest("Test");
        context.DesignRequests.Add(designRequest); 
        var floor = new Floor { Id = 1};

        // Act
        await repository.AddAsync(floor);
        var addedFloor = await context.Floors.FindAsync(1);

        // Assert
        Assert.NotNull(addedFloor);
        Assert.Equal(1, addedFloor.Id);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllFloors()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Floors.AddRange(new List<Floor>
                {
                    new() { Id = 1},
                    new() { Id = 2}
                });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new FloorRepository(context);
            var floors = await repository.GetAllAsync();

            Assert.Equal(2, floors.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnFloor()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Floors.Add(new Floor { Id = 1});
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new FloorRepository(context);
            var floor = await repository.GetByIdAsync(1);

            Assert.NotNull(floor);
            Assert.Equal(1, floor.Id);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateFloor()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Floors.Add(new Floor { Id = 1 });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new FloorRepository(context);
            var updatedFloor = new Floor {Id = 1};

            await repository.UpdateAsync(updatedFloor);
            var floor = await context.Floors.FindAsync(1);

            Assert.NotNull(floor);
            Assert.Equal(1, floor.Id);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteFloor()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Floors.Add(new Floor());
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new FloorRepository(context);
            await repository.DeleteAsync(1);
            var floor = await context.Floors.FindAsync(1);

            Assert.Null(floor);
        }
    }
}

