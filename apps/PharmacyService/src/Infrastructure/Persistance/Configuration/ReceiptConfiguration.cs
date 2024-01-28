using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.ReceiptAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
{
  public void Configure(EntityTypeBuilder<Receipt> builder)
  {
    builder.ToTable("Receipt");
    builder.HasKey(r => r.Id);
    builder.Property(r => r.Id)
        .HasConversion(id => id.Value, value => new ReceiptId(value));

    // builder.Property(p => p.MedicineIds).IsRequired();
    builder.Property(p => p.BranchId).IsRequired();
    builder.Property(p => p.PharmacistId).IsRequired();
    builder.Property(p => p.CashierId).IsRequired();
    builder.Property(p => p.CashierId).IsRequired();
    builder.Property(r => r.DateAndTime).IsRequired()
      .HasDefaultValueSql("CURRENT_TIMESTAMP");

    // builder
    //     .HasMany(e => e.MedicineIds)
    //     .WithMany();


    // builder.Property(p => p.MedicineIds)
    //     .IsRequired()
    //     .HasPostgresArrayConversion(
    //       id => id.Value,
    //       value => new MedicineId(value));

    builder.HasOne<Branch>()
                .WithMany()
                .HasForeignKey(b => b.BranchId)
                .IsRequired();

    builder.HasOne<Pharmacist>()
                .WithMany()
                .HasForeignKey(b => b.PharmacistId)
                .IsRequired();

    builder.HasOne<Cashier>()
                .WithMany()
                .HasForeignKey(b => b.CashierId)
                .IsRequired();
  }
}