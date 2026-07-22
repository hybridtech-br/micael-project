namespace Micael.Domain.Entities;

public enum DeviceType
{
    Unknown = 0,
    Camera = 1,
    Dvr = 2,
    Nvr = 3,
    AccessController = 4,
    Intercom = 5,
    PoeSwitch = 6,
    Printer = 7,
    Iot = 8
}

public enum DeviceProtocol
{
    Unknown = 0,
    Onvif = 1,
    Rtsp = 2,
    Http = 3,
    Https = 4,
    Snmp = 5,
    Proprietary = 6
}

public sealed class Device
{
    private Device()
    {
    }

    private Device(
        Guid id,
        Guid tenantId,
        string name,
        string ipAddress,
        int port,
        DeviceType type,
        DeviceProtocol protocol,
        DateTimeOffset createdAt)
    {
        Id = id;
        TenantId = tenantId;
        Name = name;
        IpAddress = ipAddress;
        Port = port;
        Type = type;
        Protocol = protocol;
        CreatedAt = createdAt;
        LastSeenAt = createdAt;
        IsOnline = true;
    }

    public Guid Id { get; private set; }
    public Guid TenantId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string? Manufacturer { get; private set; }
    public string? Model { get; private set; }
    public string? Firmware { get; private set; }
    public string? SerialNumber { get; private set; }
    public string? MacAddress { get; private set; }
    public string IpAddress { get; private set; } = string.Empty;
    public int Port { get; private set; }
    public DeviceType Type { get; private set; }
    public DeviceProtocol Protocol { get; private set; }
    public bool IsOnline { get; private set; }
    public DateTimeOffset LastSeenAt { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public static Device Register(
        Guid tenantId,
        string name,
        string ipAddress,
        int port,
        DeviceType type,
        DeviceProtocol protocol)
    {
        if (tenantId == Guid.Empty) throw new ArgumentException("TenantId is required.", nameof(tenantId));
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(ipAddress);
        if (port is < 1 or > 65535) throw new ArgumentOutOfRangeException(nameof(port));

        return new Device(
            Guid.NewGuid(),
            tenantId,
            name.Trim(),
            ipAddress.Trim(),
            port,
            type,
            protocol,
            DateTimeOffset.UtcNow);
    }

    public void MarkSeen(DateTimeOffset seenAt)
    {
        LastSeenAt = seenAt;
        IsOnline = true;
    }

    public void MarkOffline() => IsOnline = false;
}
