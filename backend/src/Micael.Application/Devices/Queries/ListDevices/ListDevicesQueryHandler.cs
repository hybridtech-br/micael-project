using MediatR;
using Micael.Application.Abstractions.Persistence;
using Micael.Application.Common.Pagination;
using Micael.Application.Devices.DTOs;

namespace Micael.Application.Devices.Queries.ListDevices;

public sealed class ListDevicesQueryHandler
    : IRequestHandler<ListDevicesQuery, PagedResult<DeviceResponse>>
{
    private readonly IDeviceRepository _deviceRepository;

    public ListDevicesQueryHandler(IDeviceRepository deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    public async Task<PagedResult<DeviceResponse>> Handle(
        ListDevicesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _deviceRepository.SearchAsync(
            request.TenantId,
            request.Page,
            request.PageSize,
            request.Search,
            request.Type,
            request.IsOnline,
            cancellationToken);

        var items = result.Items
            .Select(device => new DeviceResponse(
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
                device.CreatedAt))
            .ToList();

        return new PagedResult<DeviceResponse>(
            items,
            result.Page,
            result.PageSize,
            result.TotalItems);
    }
}
