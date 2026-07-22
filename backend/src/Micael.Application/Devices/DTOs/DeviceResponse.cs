using Micael.Domain.Entities;

namespace Micael.Application.Devices.DTOs;

public sealed record DeviceResponse(
    Guid Id,
    Guid TenantId,
    string Name,
    string? Manufacturer,
    string? Model,
    string? Firmware,
    string? SerialNumber,
    string? MacAddress,
    string IpAddress,
    int Port,
    DeviceType Type,
    DeviceProtocol Protocol,
    bool IsOnline,
    DateTimeOffset LastSeenAt,
    DateTimeOffset CreatedAt);
