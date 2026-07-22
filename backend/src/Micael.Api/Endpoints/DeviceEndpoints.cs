using MediatR;
using Micael.Application.Devices.Queries.GetDevice;

namespace Micael.Api.Endpoints;

public static class DeviceEndpoints
{
    public static IEndpointRouteBuilder MapDeviceEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/v1/devices/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var device = await sender.Send(
                new GetDeviceQuery(id),
                cancellationToken);

            return device is null
                ? Results.NotFound()
                : Results.Ok(device);
        })
        .WithName("GetDevice")
        .WithOpenApi()
        .Produces(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
