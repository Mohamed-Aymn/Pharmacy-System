using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.BranchAggregate;
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

    builder.Property(m => m.Name).IsRequired();
    builder.Property(m => m.BarCode).IsRequired();
    builder.Property(m => m.MedicineType).IsRequired();
    builder.Property(m => m.BranchId).IsRequired();

    builder.HasOne<Branch>()
                .WithMany()
                .HasForeignKey(b => b.BranchId)
                .IsRequired();
  }
}