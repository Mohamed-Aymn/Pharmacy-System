using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Common.ValueObjects;
using OrderService.Domain.Order.Entites;
using OrderService.Domain.Order.ValueObjects;

namespace OrderService.Infrastructure.Persistence.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrdersTable(builder);
    }

    private void ConfigureOrdersTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever() // refers to the manual id generation instead of letting EF core generate a new one
            .HasConversion(
                id => id.Value, // conversion to be stored in the database
                value => new OrderId(value) // conversion to be used in the applicaiton
            );

        builder.Property(o => o.CustomerId)
            .HasConversion(
                CustomerId => CustomerId.Id,
                value => new CustomerId(value)
            );

        builder.Property(o => o.RestaurantId)
            .HasConversion(
                RestaurantId => RestaurantId.Id,
                value => new RestaurantId(value)
            );

        builder.Property(o => o.AddressId)
            .HasConversion(
                AddressId => AddressId.Id,
                value => new AddressId(value)
            );

        // items is note handled yet

        builder.OwnsOne(o => o.Price); // as price contains to columns in the database
    }
}