using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Micael.Domain.Entities;

namespace Micael.Infrastructure.Persistence.Configurations;

public sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tenants");

        builder.HasKey(tenant => tenant.Id);

        builder.Property(tenant => tenant.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(tenant => tenant.Name)
            .HasColumnName("name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(tenant => tenant.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(tenant => tenant.Slug)
            .IsUnique();

        builder.Property(tenant => tenant.IsActive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(tenant => tenant.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
    }
}
