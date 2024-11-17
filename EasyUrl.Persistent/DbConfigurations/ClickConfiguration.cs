using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyUrl.Persistent.DbConfigurations;

internal static class ClickConfiguration
{
    public static void Configure(EntityTypeBuilder<Entities.Click> builder)
    {
        builder.HasKey(click => click.Id);
        builder.Property(click => click.Id).ValueGeneratedOnAdd();
    }
}