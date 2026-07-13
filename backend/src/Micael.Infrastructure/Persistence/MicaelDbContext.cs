using Microsoft.EntityFrameworkCore;
using Micael.Domain.Entities;

namespace Micael.Infrastructure.Persistence;

public sealed class MicaelDbContext(DbContextOptions<MicaelDbContext> options)
    : DbContext(options)
{
    public DbSet<Tenant> Tenants => Set<Tenant>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MicaelDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
