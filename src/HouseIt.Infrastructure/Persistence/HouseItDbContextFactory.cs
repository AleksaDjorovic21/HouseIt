using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HouseIt.Infrastructure.Persistence;

//IDesignTimeDbContextFactory<>: An interface that allows you to create a DbContext at design time.
public class HouseItDbContextFactory : IDesignTimeDbContextFactory<HouseItDbContext>
{
    public HouseItDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<HouseItDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("HouseIt.Api"));

        //Creates a new instance of HouseItDbContext with the configured options.
        return new HouseItDbContext(optionsBuilder.Options);
    }
}

