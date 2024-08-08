using Microsoft.EntityFrameworkCore;
using HouseIt.Infrastructure.Persistence;

namespace HouseIt.Test.RepositoriesTests;

public class RepositoryTestBase : IDisposable
{
    protected readonly DbContextOptions<HouseItDbContext> _options;

    public RepositoryTestBase()
    {
        _options = new DbContextOptionsBuilder<HouseItDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    public void Dispose()
    {
        using var context = new HouseItDbContext(_options);
        context.Database.EnsureDeleted();
    }
}
