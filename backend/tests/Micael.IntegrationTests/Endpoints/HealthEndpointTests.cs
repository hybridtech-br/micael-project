using System.Net;
using System.Net.Http.Json;

namespace Micael.IntegrationTests.Endpoints;

public sealed class HealthEndpointTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    [Fact]
    public async Task GetHealth_ReturnsHealthyStatus()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/health");
        var payload = await response.Content.ReadFromJsonAsync<HealthResponse>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(payload);
        Assert.Equal("Healthy", payload.Status);
    }

    private sealed record HealthResponse(string Status);
}
