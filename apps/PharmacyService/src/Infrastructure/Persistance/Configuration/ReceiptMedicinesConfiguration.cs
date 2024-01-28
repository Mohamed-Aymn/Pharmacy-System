using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.ReceiptAggregate;
using PharmacyService.Domain.ReceiptMedicinesAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class ReceiptMedicinesConfiguration : IEntityTypeConfiguration<ReceiptMedicines>
{
  public void Configure(EntityTypeBuilder<ReceiptMedicines> builder)
  {
    builder.ToTable("ReceiptMedicines");

    builder.HasKey(r => new { r.Id, r.Medicine });

    builder.Property(m => m.Medicine)
        .HasConversion(id => id.Value, value => new MedicineId(value));

    builder.Property(r => r.Id)
        .HasConversion(id => id.Value, value => new ReceiptId(value))
        .HasColumnName("ReceiptId");

    builder.HasOne<Receipt>()
        .WithMany()
        .HasForeignKey(r => r.Id)
        .IsRequired();
  }
}