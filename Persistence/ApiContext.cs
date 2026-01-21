using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
        
    }

    public override int SaveChanges()
    {
        UpdateEntityDate();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        Task.Run(UpdateEntityDate, ct);
        return base.SaveChangesAsync(ct);
    }

    private void UpdateEntityDate()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            switch (entry)
            {
                case {State: EntityState.Added}:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case {State: EntityState.Modified}:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Property(x => x.CreatedAt).IsModified = false;
                    break;
            }
        }
    }
}