using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class ToiletRepositoryTest : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddToilet()
    {
        // Arrange
        using var context = new HouseItDbContext(_options);
        var repository = new ToiletRepository(context);
        var toilet = new Toilet { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 5, Color = ColorPalette.White };

        // Act
        await repository.AddAsync(toilet);
        var addedToilet = await context.Toilets.FindAsync(1);

        // Assert
        Assert.NotNull(addedToilet);
        Assert.Equal(ToiletTypes.Bathtub, addedToilet.ToiletType);
        Assert.Equal(5, addedToilet.Sqrm);
        Assert.Equal(ColorPalette.White, addedToilet.Color);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllToilets()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Toilets.AddRange(new List<Toilet>
                {
                    new() { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 3, Color = ColorPalette.Blue },
                    new() { Id = 2, ToiletType = ToiletTypes.Shower, Sqrm = 5, Color = ColorPalette.White }
                });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new ToiletRepository(context);
            var toilets = await repository.GetAllAsync();

            Assert.Equal(2, toilets.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnToilet()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Toilets.Add(new Toilet { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 3, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new ToiletRepository(context);
            var toilet = await repository.GetByIdAsync(1);

            Assert.NotNull(toilet);
            Assert.Equal(ToiletTypes.Bathtub, toilet.ToiletType);
            Assert.Equal(3, toilet.Sqrm);
            Assert.Equal(ColorPalette.Blue, toilet.Color);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateToilet()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Toilets.Add(new Toilet { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 3, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new ToiletRepository(context);
            var updatedToilet = new Toilet { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 5, Color = ColorPalette.White };

            await repository.UpdateAsync(updatedToilet);
            var toilet = await context.Toilets.FindAsync(1);

            Assert.NotNull(toilet);
            Assert.Equal(ToiletTypes.Bathtub, toilet.ToiletType);
            Assert.Equal(5, toilet.Sqrm);
            Assert.Equal(ColorPalette.White, toilet.Color);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteToilet()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Toilets.Add(new Toilet { Id = 1, ToiletType = ToiletTypes.Bathtub, Sqrm = 3, Color = ColorPalette.Blue });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new ToiletRepository(context);
            await repository.DeleteAsync(1);
            var toilet = await context.Toilets.FindAsync(1);

            Assert.Null(toilet);
        }
    }
}

