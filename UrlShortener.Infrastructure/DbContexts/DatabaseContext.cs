using EasyUrl.Persistent.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyUrl.Persistent.DbContexts;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Tag> Tags { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Tag>().ToTable("Tag");
        builder.Entity<Tag>().HasKey(tag => tag.Id);
        builder.Entity<Tag>().Property(tag => tag.Id).ValueGeneratedOnAdd();

        builder.Entity<Tag>().Property(tag => tag.Code).IsRequired();
        builder.Entity<Tag>().Property(tag => tag.Code).HasMaxLength(10);

        builder.Entity<Tag>().Property(tag => tag.Url).IsRequired();
        builder.Entity<Tag>().Property(tag => tag.Url).HasMaxLength(250);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
    {
        // set CreatedDate when entity is EntityState.Added.
        var addedEntities = ChangeTracker.Entries().Where(entities => entities.State == EntityState.Added).ToList();
        addedEntities.ForEach(entity =>
        {
            entity.Property("CreatedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
        });

        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}