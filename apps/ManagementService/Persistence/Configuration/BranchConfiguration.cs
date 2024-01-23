using ManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementService.Persistence.Configuration;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
  public void Configure(EntityTypeBuilder<Branch> builder)
  {
    builder.ToTable("Branch");
    builder.HasKey(m => m.Name);
  }
}