using System.Net;
using FluentValidation;
using Micael.Domain.Entities;

namespace Micael.Application.Devices.Commands.RegisterDevice;

public sealed class RegisterDeviceValidator : AbstractValidator<RegisterDeviceCommand>
{
    public RegisterDeviceValidator()
    {
        RuleFor(command => command.TenantId)
            .NotEmpty()
            .WithMessage("TenantId is required.");

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Device name is required.")
            .MaximumLength(200)
            .WithMessage("Device name must not exceed 200 characters.");

        RuleFor(command => command.IpAddress)
            .NotEmpty()
            .WithMessage("IP address is required.")
            .Must(BeAValidIpAddress)
            .WithMessage("IP address must be a valid IPv4 or IPv6 address.");

        RuleFor(command => command.Port)
            .InclusiveBetween(1, 65535)
            .WithMessage("Port must be between 1 and 65535.");

        RuleFor(command => command.Type)
            .IsInEnum()
            .WithMessage("Device type is invalid.")
            .NotEqual(DeviceType.Unknown)
            .WithMessage("Device type must be specified.");

        RuleFor(command => command.Protocol)
            .IsInEnum()
            .WithMessage("Device protocol is invalid.")
            .NotEqual(DeviceProtocol.Unknown)
            .WithMessage("Device protocol must be specified.");
    }

    private static bool BeAValidIpAddress(string ipAddress) =>
        IPAddress.TryParse(ipAddress?.Trim(), out _);
}
