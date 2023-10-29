using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Item.Entites;

namespace OrderService.Infrastructure.Persistence.Configuration;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        ConfigureOrdersTable(builder);
    }

    private void ConfigureOrdersTable(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("item");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever() // refers to the manual id generation instead of letting EF core generate a new one
            .HasConversion(
                id => id.Value, // conversion to be stored in the database
                value => new Domain.Item.ValueObjects.ItemId(value) // conversion to be used in the applicaiton
            );
    }
}