using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Address.Entities;
using OrderService.Domain.Address.ValueObjects;
using OrderService.Domain.Common.ValueObjects;

namespace OrderService.Infrastructure.Persistence.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        ConfigureAddressesTable(builder);
    }

    private void ConfigureAddressesTable(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever() // refers to the manual id generation instead of letting EF core generate a new one
            .HasConversion(
                id => id.Value, // conversion to be stored in the database
                value => new AddressId(value) // conversion to be used in the applicaiton
            );

        builder.Property(o => o.CustomerId)
            .HasConversion(
                CustomerId => CustomerId.Id,
                value => new CustomerId(value)
            );
    }
}