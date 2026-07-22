namespace Micael.Application.Devices.Commands.RegisterDevice;

public sealed class DuplicateDeviceException : InvalidOperationException
{
    public DuplicateDeviceException(Guid tenantId, string ipAddress, int port)
        : base($"A device with endpoint {ipAddress}:{port} is already registered for tenant {tenantId}.")
    {
        TenantId = tenantId;
        IpAddress = ipAddress;
        Port = port;
    }

    public Guid TenantId { get; }

    public string IpAddress { get; }

    public int Port { get; }
}
