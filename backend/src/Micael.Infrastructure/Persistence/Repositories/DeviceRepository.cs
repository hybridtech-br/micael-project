using Microsoft.EntityFrameworkCore;
using Micael.Application.Abstractions.Persistence;
using Micael.Domain.Entities;

namespace Micael.Infrastructure.Persistence.Repositories;

public sealed class DeviceRepository(MicaelDbContext dbContext) : IDeviceRepository
{
    public Task<Device?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Devices
            .AsNoTracking()
            .SingleOrDefaultAsync(device => device.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Device>> ListByTenantAsync(
        Guid tenantId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Devices
            .AsNoTracking()
            .Where(device => device.TenantId == tenantId)
            .OrderBy(device => device.Name)
            .ThenBy(device => device.IpAddress)
            .ToListAsync(cancellationToken);
    }

    public Task<bool> ExistsAsync(
        Guid tenantId,
        string ipAddress,
        int port,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(ipAddress);

        var normalizedIpAddress = ipAddress.Trim();

        return dbContext.Devices.AnyAsync(
            device => device.TenantId == tenantId
                && device.IpAddress == normalizedIpAddress
                && device.Port == port,
            cancellationToken);
    }

    public async Task AddAsync(
        Device device,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(device);
        await dbContext.Devices.AddAsync(device, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
