using Microsoft.EntityFrameworkCore;
using UrlShortener.Persistent.Entities;

namespace UrlShortener.Persistent.DbContexts
{
    public sealed class DatabaseContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Tag>().ToTable("Tag");
            builder.Entity<Tag>().HasKey(tag => tag.Id);
            builder.Entity<Tag>().Property(tag => tag.Id).ValueGeneratedOnAdd();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
