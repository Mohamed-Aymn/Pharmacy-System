using ManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagementService.Persistence.Configuration;

public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
{
  public void Configure(EntityTypeBuilder<Manager> builder)
  {
    builder.ToTable("Manager");
    builder.HasKey(m => m.Name);
  }
}