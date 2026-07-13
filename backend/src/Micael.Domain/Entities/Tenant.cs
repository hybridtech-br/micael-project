namespace Micael.Domain.Entities;

public sealed class Tenant
{
    private Tenant()
    {
    }

    private Tenant(Guid id, string name, string slug, bool isActive, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        Slug = slug;
        IsActive = isActive;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Slug { get; private set; } = string.Empty;

    public bool IsActive { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public static Tenant Create(string name, string slug)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        return new Tenant(
            Guid.NewGuid(),
            name.Trim(),
            slug.Trim().ToLowerInvariant(),
            true,
            DateTimeOffset.UtcNow);
    }
}
