using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Micael.Infrastructure.Persistence;

namespace Micael.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MicaelDatabase")
            ?? throw new InvalidOperationException(
                "Connection string 'MicaelDatabase' was not configured.");

        services.AddDbContext<MicaelDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }
}
