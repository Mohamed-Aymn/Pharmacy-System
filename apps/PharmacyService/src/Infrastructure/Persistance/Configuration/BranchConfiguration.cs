using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace ManagementService.Persistence.Configuration;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
  public void Configure(EntityTypeBuilder<Branch> builder)
  {
    builder.ToTable("Branch");
    builder.HasKey(b => b.Id);
    builder.Property(b => b.Id)
        .HasConversion(id => id.Value, value => new BranchId(value));
  }
}