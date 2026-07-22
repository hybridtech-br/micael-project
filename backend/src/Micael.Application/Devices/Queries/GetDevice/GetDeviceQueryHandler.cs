using MediatR;
using Micael.Application.Abstractions.Persistence;
using Micael.Application.Devices.DTOs;

namespace Micael.Application.Devices.Queries.GetDevice;

public sealed class GetDeviceQueryHandler
    : IRequestHandler<GetDeviceQuery, DeviceResponse?>
{
    private readonly IDeviceRepository _deviceRepository;

    public GetDeviceQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<DeviceResponse?> Handle(
        GetDeviceQuery request,
        CancellationToken cancellationToken)
    {
        var device = await _deviceRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (device is null)
        {
            return null;
        }

        return new DeviceResponse(
            device.Id,
            device.TenantId,
            device.Name,
            device.Manufacturer,
            device.Model,
            device.Firmware,
            device.SerialNumber,
            device.MacAddress,
            device.IpAddress,
            device.Port,
            device.Type,
            device.Protocol,
            device.IsOnline,
            device.LastSeenAt,
            device.CreatedAt);
    }
}
