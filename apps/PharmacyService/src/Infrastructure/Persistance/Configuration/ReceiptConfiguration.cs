using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.MedicineAggregate;
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
    builder.Property(r => r.DateAndTime).HasDefaultValueSql("CURRENT_TIMESTAMP");

    // medicine relastion should be configured here

    builder.HasOne<Branch>()
      .WithMany()
      .HasForeignKey(b => b.Id);
    builder.HasOne<Pharmacist>()
      .WithMany()
      .HasForeignKey(p => p.Id);
    builder.HasOne<Cashier>()
      .WithMany()
      .HasForeignKey(p => p.Id);
  }
}