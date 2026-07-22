using MediatR;
using Micael.Application.Common.Pagination;
using Micael.Application.Devices.DTOs;
using Micael.Domain.Entities;

namespace Micael.Application.Devices.Queries.ListDevices;

public sealed record ListDevicesQuery(
    Guid TenantId,
    int Page = 1,
    int PageSize = 25,
    string? Search = null,
    DeviceType? Type = null,
    bool? IsOnline = null)
    : IRequest<PagedResult<DeviceResponse>>;
