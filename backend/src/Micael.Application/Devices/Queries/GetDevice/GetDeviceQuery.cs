using MediatR;
using Micael.Application.Devices.Queries.GetDevice;

namespace Micael.Application.Devices.Queries.GetDevice;

public sealed record GetDeviceQuery(Guid Id) : IRequest<DeviceResponse?>;
