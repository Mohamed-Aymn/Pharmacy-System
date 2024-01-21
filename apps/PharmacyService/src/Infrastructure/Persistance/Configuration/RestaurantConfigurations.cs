using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Restaurant.Entites;
using OrderService.Domain.Restaurant.ValueObjects;

namespace OrderService.Infrastructure.Persistence.Configuration;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        ConfigureRestaurantTable(builder);
    }

    private void ConfigureRestaurantTable(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("restaurant");

        builder.HasKey(r => r.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever() // refers to the manual id generation instead of letting EF core generate a new one
            .HasConversion(
                id => id.Value, // conversion to be stored in the database
                value => new RestaurantId(value) // conversion to be used in the applicaiton
            );

        // items are not handled yet
    }
}