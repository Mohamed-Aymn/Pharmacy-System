using ManagementService.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using PharmacyService.Domain.BranchAggregate;
using PharmacyService.Domain.CashierAggregate;
using PharmacyService.Domain.MedicineAggregate;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.ReceiptAggregate;

namespace PharmacyService.Infrastructure.Persistence;

public class PharmacyServiceDbContext : DbContext
{
  public PharmacyServiceDbContext(DbContextOptions<PharmacyServiceDbContext> options) : base(options) { }

  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {

  //   modelBuilder.ApplyConfigurationsFromAssembly(typeof(PharmacyServiceDbContext).Assembly);
  //   base.OnModelCreating(modelBuilder);
  // }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
    .ApplyConfiguration(new BranchConfiguration())
    .ApplyConfiguration(new CashierConfiguration())
    .ApplyConfiguration(new MedicineConfiguration())
    .ApplyConfiguration(new PharmacistConfiguration())
    .ApplyConfiguration(new ReceiptConfiguration());
  }

  public DbSet<Branch> Branches { get; set; }
  public DbSet<Cashier> Cashiers { get; set; }
  public DbSet<Medicine> Medicines { get; set; }
  public DbSet<Pharmacist> Pharmacists { get; set; }
  public DbSet<Receipt> Receipts { get; set; }
}