using Microsoft.EntityFrameworkCore;
// using ManagementService.EntityMapping;
using ManagementService.Models;
using ManagementService.Persistence.Configuration;

namespace ManagementService.Persistence;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  public DbSet<Manager> Mangers { get; set; }
  // public DbSet<Medicine> Medicines { get; set; }
  public DbSet<Branch> Branches { get; set; }
  // public DbSet<Employee> Employees { get; set; }
  // public DbSet<Company> Companies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
        .ApplyConfiguration(new ManagerConfiguration())
        .ApplyConfiguration(new BranchConfiguration());
  }
  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  // modelBuilder
  // .ApplyConfiguration(new CustomerConfiguration())
  // .ApplyConfiguration(new MedicineConfiguration());
  // }
}