using System.Net;
using System.Net.Http.Json;

namespace Micael.IntegrationTests.Endpoints;

public sealed class SystemInfoEndpointTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    [Fact]
    public async Task GetSystemInfo_ReturnsCurrentApplicationMetadata()
    {
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/system/info");
        var payload = await response.Content.ReadFromJsonAsync<SystemInfoResponse>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(payload);
        Assert.Equal("MICAEL", payload.Name);
        Assert.Equal("0.2.0", payload.Version);
        Assert.Equal("Development", payload.Environment);
    }

    private sealed record SystemInfoResponse(string Name, string Version, string Environment);
}
