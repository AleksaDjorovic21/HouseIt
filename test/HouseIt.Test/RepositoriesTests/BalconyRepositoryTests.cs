using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class BalconyRepositoryTest : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddBalcony()
    {
        //Arrange
        using var context = new HouseItDbContext(_options);
        var repository = new BalconyRepository(context);
        var balcony = new Balcony(BalconySize.Large, BalconyType.Open) { Id = 1 };

        await repository.AddAsync(balcony);
        var addBalcony = await context.Balconies.FindAsync(1);

        Assert.NotNull(addBalcony);
        Assert.Equal(BalconySize.Large, addBalcony.Size);
        Assert.Equal(BalconyType.Open, addBalcony.Type);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllBalconies()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.Balconies.AddRange(new List<Balcony>
            {
                new(BalconySize.Small, BalconyType.Covered) {Id = 1},
                new(BalconySize.Medium, BalconyType.Open) {Id = 2}
            });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new BalconyRepository(context);
            var balconies = await repository.GetAllAsync();

            Assert.Equal(2, balconies.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnBalcony()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.Balconies.Add(new Balcony(BalconySize.Small, BalconyType.Covered) { Id = 1 });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new BalconyRepository(context);
            var balcony = await repository.GetByIdAsync(1);

            Assert.NotNull(balcony);
            Assert.Equal(BalconySize.Small, balcony.Size);
            Assert.Equal(BalconyType.Covered, balcony.Type);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateBalcony()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Balconies.Add(new Balcony(BalconySize.Small, BalconyType.Covered) { Id = 1 });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new BalconyRepository(context);
            var updatedBalcony = new Balcony(BalconySize.Large, BalconyType.Open) { Id = 1 };

            await repository.UpdateAsync(updatedBalcony);
            var balcony = await context.Balconies.FindAsync(1);

            Assert.NotNull(balcony);
            Assert.Equal(BalconySize.Large, balcony.Size);
            Assert.Equal(BalconyType.Open, balcony.Type);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteBalcony()
    {
        // Arrange
        using (var context = new HouseItDbContext(_options))
        {
            context.Balconies.Add(new Balcony(BalconySize.Small, BalconyType.Covered) { Id = 1 });
            await context.SaveChangesAsync();
        }

        // Act & Assert
        using (var context = new HouseItDbContext(_options))
        {
            var repository = new BalconyRepository(context);
            await repository.DeleteAsync(1);
            var balcony = await context.Balconies.FindAsync(1);

            Assert.Null(balcony);
        }
    }
}

