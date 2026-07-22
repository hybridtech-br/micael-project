using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Micael.Domain.Entities;

namespace Micael.Infrastructure.Persistence.Configurations;

public sealed class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("devices");
        builder.HasKey(device => device.Id);

        builder.Property(device => device.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(device => device.IpAddress)
            .HasMaxLength(45)
            .IsRequired();

        builder.Property(device => device.Port)
            .IsRequired();

        builder.Property(device => device.Type)
            .HasConversion<string>()
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(device => device.Protocol)
            .HasConversion<string>()
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(device => device.Manufacturer).HasMaxLength(120);
        builder.Property(device => device.Model).HasMaxLength(120);
        builder.Property(device => device.Firmware).HasMaxLength(120);
        builder.Property(device => device.SerialNumber).HasMaxLength(120);
        builder.Property(device => device.MacAddress).HasMaxLength(17);

        builder.HasIndex(device => new { device.TenantId, device.IpAddress, device.Port })
            .IsUnique();

        builder.HasIndex(device => new { device.TenantId, device.IsOnline });
    }
}
