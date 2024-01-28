using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class CashierConfiguration : IEntityTypeConfiguration<Cashier>
{
  public void Configure(EntityTypeBuilder<Cashier> builder)
  {
    builder.ToTable("Cashier");
    builder.HasKey(c => c.Id);
    builder.Property(c => c.Id)
        .HasConversion(id => id.Value, value => new CashierId(value));

    builder.Property(c => c.Name).IsRequired();
    builder.Property(c => c.Email).IsRequired();
    builder.Property(c => c.PhoneNumber).IsRequired();
  }
}