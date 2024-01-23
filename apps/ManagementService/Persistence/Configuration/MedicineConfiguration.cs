using ManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementService.Persistence.Configuration;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
  public void Configure(EntityTypeBuilder<Medicine> builder)
  {
    builder.ToTable("Medicine");
    builder.HasKey(m => m.Name);
  }
}