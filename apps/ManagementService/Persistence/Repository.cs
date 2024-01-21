using Microsoft.EntityFrameworkCore;

namespace ManagementService.Persistence;

public class Repository<Model, Tid> where Model : class
{
  private readonly AppDbContext _context;
  public Repository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Model>> GetAllAsync()
  {
    return await _context.Set<Model>().ToListAsync();
  }

  public async Task<Model?> GetByIdAsync(Tid id)
  {
    return await _context.Set<Model>().FindAsync(id);
  }

  public void Update(Model model)
  {
    _context.Set<Model>().Update(model);
  }
  public void Add(Model model)
  {
    _context.Set<Model>().Add(model);
  }

  public void Remove(Model model)
  {
    _context.Set<Model>().Remove(model);
  }

  public Task SaveChangesAsync()
  {
    return _context.SaveChangesAsync();
  }
}