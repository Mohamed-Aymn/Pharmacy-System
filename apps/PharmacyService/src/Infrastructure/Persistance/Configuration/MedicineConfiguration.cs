using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.MedicineAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
  public void Configure(EntityTypeBuilder<Medicine> builder)
  {
    builder.ToTable("Medicine");
    builder.HasKey(m => m.Id);
    builder.Property(m => m.Id)
        .HasConversion(id => id.Value, value => new MedicineId(value));
    builder.HasOne<Branch>()
      .WithMany()
      .HasForeignKey(b => b.Id);
  }
}