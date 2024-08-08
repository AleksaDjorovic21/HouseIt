using HouseIt.ConsoleApp;
using HouseIt.ConsoleApp.Builders;
using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;
using HouseIt.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

// Configure HttpClient
serviceCollection.AddHttpClient<IRequestManager, HttpRequestManager>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5031/");
});

//Dependencies
serviceCollection.AddSingleton<IUserInterface, UserConsoleInterface>();
serviceCollection.AddSingleton<IDesignRequestDocument, DesignRequestConsoleDocument>();
serviceCollection.AddTransient<DesignRequestBuilder>();
serviceCollection.AddTransient<RequestManager>();

//Service provider
var serviceProvider = serviceCollection.BuildServiceProvider();

Console.Write("Enter the name for the request: ");
string? requestName = Console.ReadLine();

if (requestName is null)
{
    Console.WriteLine("Request name cannot be null.");
    return;
}

var designRequest = new DesignRequest(requestName);

var builder = serviceProvider.GetRequiredService<DesignRequestBuilder>();
builder.Build(designRequest);

var manager = serviceProvider.GetRequiredService<RequestManager>();
await manager.SubmitRequestAsync(designRequest);

Console.WriteLine("Design request submitted successfully");

