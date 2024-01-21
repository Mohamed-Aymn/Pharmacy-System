namespace ManagementService.Persistence;

public interface IRepository<Model, Tid> where Model : class
{
  Task<IEnumerable<Model>> GetAllAsync();
  Task<Model?> GetByIdAsync(Tid id);
  void Update(Model model);
  void Add(Model model);
  void Remove(Model model);
  Task SaveChangesAsync();
}