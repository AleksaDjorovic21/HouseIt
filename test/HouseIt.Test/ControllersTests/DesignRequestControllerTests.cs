using HouseIt.Core.Domain;
using HouseIt.Api.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;

namespace HouseIt.Tests.Controllers;

public class DesignRequestControllerTests(WebApplicationFactory<DesignRequestController> factory) 
    : IClassFixture<WebApplicationFactory<DesignRequestController>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GetAll_ShouldReturnAllDesignRequests()
    {
        // Act
        var response = await _client.GetAsync("/api/designrequest");
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var designRequests = await response.Content.ReadFromJsonAsync<List<DesignRequest>>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        });

        // Assert
        designRequests.Should().NotBeNull();
        designRequests.Should().HaveCountGreaterThan(0);
    }

    [Fact]
    public async Task GetById_ShouldReturnSpecificDesignRequest()
    {
        // Act
        var response = await _client.GetAsync("/api/designrequest/1");
        response.EnsureSuccessStatusCode();

        // Deserialize response
        var designRequest = await response.Content.ReadFromJsonAsync<DesignRequest>(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        });

        // Assert
        designRequest.Should().NotBeNull();
        designRequest!.Id.Should().Be(1);
    }
}
