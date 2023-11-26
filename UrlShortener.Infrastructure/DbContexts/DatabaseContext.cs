using Microsoft.EntityFrameworkCore;
using UrlShortener.Persistent.Entities;

namespace UrlShortener.Persistent.DbContexts
{
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

            builder.Entity<Tag>().Property(tag => tag.IsDeleted).HasDefaultValue(false);
            builder.Entity<Tag>().Property(tag => tag.DeletedDate).IsRequired(false);

            builder.Entity<Tag>().HasQueryFilter(tag => tag.IsDeleted == false);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            // set CreatedDate and ModifiedDate when entity is EntityState.Added.
            var addedEntities = ChangeTracker.Entries().Where(entities => entities.State == EntityState.Added).ToList();
            addedEntities.ForEach(entity =>
            {
                entity.Property("CreatedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
                entity.Property("ModifiedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
            });

            // set ModifiedDate when entity is EntityState.Modified.
            var modifiedEntities = ChangeTracker.Entries().Where(entity => entity.State == EntityState.Modified).ToList();
            modifiedEntities.ForEach(entity =>
            {
                entity.Property("ModifiedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
            });

            // set IsDeleted and DeletedDate when entity is EntityState.Deleted.
            var deletedEntities = ChangeTracker.Entries().Where(entity => entity.State == EntityState.Deleted).ToList();
            deletedEntities.ForEach(entity =>
            {
                entity.State = EntityState.Modified;
                entity.Property("IsDeleted").CurrentValue = true;
                entity.Property("DeletedDate").CurrentValue = DateTimeOffset.Now.ToLocalTime();
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
