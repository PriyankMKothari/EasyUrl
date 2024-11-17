using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyUrl.Persistent.DbConfigurations;

internal static class EasyUrlConfiguration
{
    public static void Configure(EntityTypeBuilder<Entities.EasyUrl> builder)
    {
        builder.HasKey(easyUrl => easyUrl.Id);
        builder.Property(easyUrl => easyUrl.Id).ValueGeneratedOnAdd();

        builder.Property(easyUrl => easyUrl.ShortUrl).IsRequired();
        builder.Property(easyUrl => easyUrl.ShortUrl).HasMaxLength(10);

        builder.Property(easyUrl => easyUrl.OriginalUrl).IsRequired();
        builder.Property(easyUrl => easyUrl.OriginalUrl).HasMaxLength(2000);
        
        builder
            .HasMany(easyUrl => easyUrl.Clicks)
            .WithOne(click => click.EasyUrl)
            .HasForeignKey(click => click.EasyUrlId);
    }
}