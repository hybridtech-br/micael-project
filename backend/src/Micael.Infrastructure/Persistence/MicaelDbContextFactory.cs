using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Micael.Infrastructure.Persistence;

public sealed class MicaelDbContextFactory : IDesignTimeDbContextFactory<MicaelDbContext>
{
    public MicaelDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__MicaelDatabase")
            ?? "Host=localhost;Port=5432;Database=micael;Username=micael;Password=micael_dev_only";

        var options = new DbContextOptionsBuilder<MicaelDbContext>()
            .UseNpgsql(connectionString)
            .Options;

        return new MicaelDbContext(options);
    }
}
