using MediatR;
using Micael.Application.Abstractions.Persistence;
using Micael.Domain.Entities;

namespace Micael.Application.Devices.Commands.RegisterDevice;

public sealed class RegisterDeviceCommandHandler
    : IRequestHandler<RegisterDeviceCommand, RegisterDeviceResponse>
{
    private readonly IDeviceRepository _deviceRepository;

    public RegisterDeviceCommandHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<RegisterDeviceResponse> Handle(
        RegisterDeviceCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var normalizedIpAddress = command.IpAddress.Trim();

        var alreadyExists = await _deviceRepository.ExistsAsync(
            command.TenantId,
            normalizedIpAddress,
            command.Port,
            cancellationToken);

        if (alreadyExists)
        {
            throw new DuplicateDeviceException(
                command.TenantId,
                normalizedIpAddress,
                command.Port);
        }

        var device = Device.Register(
            command.TenantId,
            command.Name,
            normalizedIpAddress,
            command.Port,
            command.Type,
            command.Protocol);

        await _deviceRepository.AddAsync(device, cancellationToken);
        await _deviceRepository.SaveChangesAsync(cancellationToken);

        return new RegisterDeviceResponse(
            device.Id,
            device.TenantId,
            device.Name,
            device.IpAddress,
            device.Port,
            device.Type,
            device.Protocol,
            device.IsOnline,
            device.CreatedAt);
    }
}
