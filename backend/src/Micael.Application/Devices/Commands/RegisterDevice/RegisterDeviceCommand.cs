using MediatR;
using Micael.Domain.Entities;

namespace Micael.Application.Devices.Commands.RegisterDevice;

public sealed record RegisterDeviceCommand(
    Guid TenantId,
    string Name,
    string IpAddress,
    int Port,
    DeviceType Type,
    DeviceProtocol Protocol) : IRequest<RegisterDeviceResponse>;
