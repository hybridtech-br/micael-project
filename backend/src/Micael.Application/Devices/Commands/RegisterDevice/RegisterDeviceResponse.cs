using Micael.Domain.Entities;

namespace Micael.Application.Devices.Commands.RegisterDevice;

public sealed record RegisterDeviceResponse(
    Guid Id,
    Guid TenantId,
    string Name,
    string IpAddress,
    int Port,
    DeviceType Type,
    DeviceProtocol Protocol,
    bool IsOnline,
    DateTimeOffset CreatedAt);
