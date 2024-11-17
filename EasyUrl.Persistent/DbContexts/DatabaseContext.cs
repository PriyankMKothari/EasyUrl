using EasyUrl.Persistent.DbConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EasyUrl.Persistent.DbContexts;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Entities.EasyUrl> EasyUrls { get; set; }
    public DbSet<Entities.Click> Clicks { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        base.Database.EnsureCreatedAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        EasyUrlConfiguration.Configure(modelBuilder.Entity<Entities.EasyUrl>());
        ClickConfiguration.Configure(modelBuilder.Entity<Entities.Click>());
    }

    public override async Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        var entityEntries = ChangeTracker
            .Entries()
            .Where(entityEntry =>
                entityEntry is
                {
                    State: EntityState.Added or
                    EntityState.Modified or
                    EntityState.Deleted
                })
            .ToList();

        foreach (var entityEntry in entityEntries)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Property("CreatedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
                    break;

                case EntityState.Modified:
                    entityEntry.Property("ModifiedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
                    break;

                case EntityState.Deleted:
                    entityEntry.Property("ModifiedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
                    entityEntry.Property("DeletedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
                    entityEntry.Property("IsDeleted").CurrentValue = true;
                    
                    entityEntry.State = EntityState.Modified;
                    break;
            }
        }

        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}