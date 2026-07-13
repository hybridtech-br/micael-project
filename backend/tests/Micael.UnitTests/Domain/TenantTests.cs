using Micael.Domain.Entities;

namespace Micael.UnitTests.Domain;

public sealed class TenantTests
{
    [Fact]
    public void Create_WithValidValues_CreatesActiveTenant()
    {
        var beforeCreation = DateTimeOffset.UtcNow;

        var tenant = Tenant.Create("Condomínio Aurora", "Condominio-Aurora");

        Assert.NotEqual(Guid.Empty, tenant.Id);
        Assert.Equal("Condomínio Aurora", tenant.Name);
        Assert.Equal("condominio-aurora", tenant.Slug);
        Assert.True(tenant.IsActive);
        Assert.InRange(tenant.CreatedAt, beforeCreation, DateTimeOffset.UtcNow);
    }
}
