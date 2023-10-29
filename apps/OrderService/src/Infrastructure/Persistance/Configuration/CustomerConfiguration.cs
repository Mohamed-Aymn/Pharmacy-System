using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.Customer.Entites;

namespace OrderService.Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        ConfigureCustomersTable(builder);
    }

    private void ConfigureCustomersTable(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever() 
            .HasConversion(
                id => id.Value,
                value => new Domain.Customer.ValueObjects.CustomerId(value) // conversion to be used in the applicaiton
            );

        // addresses list is not defined here yet
    }
}