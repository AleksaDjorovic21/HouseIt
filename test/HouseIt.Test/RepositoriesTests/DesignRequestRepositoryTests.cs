using HouseIt.Core.Domain;
using HouseIt.Infrastructure.Persistence;
using HouseIt.Infrastructure.Repositories;
using HouseIt.Test.RepositoriesTests;

namespace HouseIt.Tests.RepositoriesTests;

public class DesignRequestRepositoryTests : RepositoryTestBase
{
    [Fact]
    public async Task AddAsync_ShouldAddDesignRequest()
    {
        using var context = new HouseItDbContext(_options);
        var repository = new DesignRequestRepository(context);
        var designRequest = new DesignRequest("TestRequest") { Id = 1 };

        await repository.AddAsync(designRequest);
        var addedRequest = await context.DesignRequests.FindAsync(1);

        Assert.NotNull(addedRequest);
        Assert.Equal("TestRequest", addedRequest.Name);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllDesignRequests()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.DesignRequests.AddRange(new List<DesignRequest>
            {
                new("Request1") { Id = 1 },
                new("Request2") { Id = 2 }
            });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new DesignRequestRepository(context);
            var requests = await repository.GetAllAsync();

            Assert.Equal(2, requests.Count());
        }
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnDesignRequest()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.DesignRequests.Add(new DesignRequest("TestRequest") { Id = 1 });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new DesignRequestRepository(context);
            var request = await repository.GetByIdAsync(1);

            Assert.NotNull(request);
            Assert.Equal("TestRequest", request.Name);
        }
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateDesignRequest()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.DesignRequests.Add(new DesignRequest("TestRequest") { Id = 1 });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new DesignRequestRepository(context);
            var updatedRequest = new DesignRequest("UpdatedRequest") { Id = 1 };

            await repository.UpdateAsync(updatedRequest);
            var request = await context.DesignRequests.FindAsync(1);

            Assert.NotNull(request);
            Assert.Equal("UpdatedRequest", request.Name);
        }
    }

    [Fact]
    public async Task DeleteAsync_ShouldDeleteDesignRequest()
    {
        using (var context = new HouseItDbContext(_options))
        {
            context.DesignRequests.Add(new DesignRequest("TestRequest") { Id = 1 });
            await context.SaveChangesAsync();
        }

        using (var context = new HouseItDbContext(_options))
        {
            var repository = new DesignRequestRepository(context);
            await repository.DeleteAsync(1);
            var request = await context.DesignRequests.FindAsync(1);

            Assert.Null(request);
        }
    }
}
