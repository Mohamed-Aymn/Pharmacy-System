using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class PharmacistConfiguration : IEntityTypeConfiguration<Pharmacist>
{
  public void Configure(EntityTypeBuilder<Pharmacist> builder)
  {
    builder.ToTable("Pharmacy");
    builder.HasKey(p => p.Id);
    builder.Property(p => p.Id)
      .HasConversion(id => id.Value, value => new PharmacistId(value));

    builder.Property(p => p.Name).IsRequired();
    builder.Property(p => p.Email).IsRequired();
    builder.Property(p => p.PhoneNumber).IsRequired();
    builder.Property(p => p.Role).IsRequired();
  }
}