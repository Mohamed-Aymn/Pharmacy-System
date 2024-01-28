using PharmacyService.Application.Common.Interfaces.Persistance;

namespace PharmacyService.Application.Common.Interfaces.Persistence.Respositories;

public interface IMedicineRepository<Medicine, MedicineId> : IRepository<Medicine, MedicineId>
{
}