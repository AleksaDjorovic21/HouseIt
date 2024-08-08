using System.Net.Http.Json;
using HouseIt.Core.Domain;
using HouseIt.Core.Interfaces;

namespace HouseIt.Infrastructure.Service;

public class HttpRequestManager(HttpClient httpClient) : IRequestManager
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task SubmitRequestAsync(DesignRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/DesignRequest", request);
        response.EnsureSuccessStatusCode();
    }
}
