using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class KitchenRepositoryTest : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddKitchen()
    {
        // Arrange
        using var context = new HouseItDbContext(_options);
        var repository = new KitchenRepository(context);
        var kitchen = new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White };

        // Act
        await repository.AddAsync(kitchen);
        await context.SaveChangesAsync();
        var addedKitchen = await context.Kitchens.FindAsync(1);

        // Assert
        Assert.NotNull(addedKitchen);
        Assert.True(addedKitchen.HasDiningArea);
        Assert.Equal(20, addedKitchen.Sqrm);
        Assert.Equal(ColorPalette.White, addedKitchen.Color);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllKitchens()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Kitchens.AddRange(new List<Kitchen>
                {
                    new() { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White },
                    new() { Id = 2, HasDiningArea = false, Sqrm = 15, Color = ColorPalette.Blue }
                });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new KitchenRepository(context);
            var kitchens = await repository.GetAllAsync();

            Assert.Equal(2, kitchens.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnKitchen()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Kitchens.Add(new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new KitchenRepository(context);
            var kitchen = await repository.GetByIdAsync(1);

            Assert.NotNull(kitchen);
            Assert.True(kitchen.HasDiningArea);
            Assert.Equal(20, kitchen.Sqrm);
            Assert.Equal(ColorPalette.White, kitchen.Color);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateKitchen()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Kitchens.Add(new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new KitchenRepository(context);
            var updatedKitchen = new Kitchen { Id = 1, HasDiningArea = false, Sqrm = 25, Color = ColorPalette.Blue };

            await repository.UpdateAsync(updatedKitchen);
            await context.SaveChangesAsync();
            var kitchen = await context.Kitchens.FindAsync(1);

            Assert.NotNull(kitchen);
            Assert.False(kitchen.HasDiningArea);
            Assert.Equal(25, kitchen.Sqrm);
            Assert.Equal(ColorPalette.Blue, kitchen.Color);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteKitchen()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Kitchens.Add(new Kitchen { Id = 1, HasDiningArea = true, Sqrm = 20, Color = ColorPalette.White });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new KitchenRepository(context);
            await repository.DeleteAsync(1);
            await context.SaveChangesAsync();
            var kitchen = await context.Kitchens.FindAsync(1);

            Assert.Null(kitchen);
        }
    }
}

