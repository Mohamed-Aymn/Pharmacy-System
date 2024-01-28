using PharmacyService.Application.Common.Interfaces.Persistance;
using PharmacyService.Domain.PharmacistAggregate;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Common.Interfaces.Persistence.Respositories;

public interface IPharmacistRepository<Pharmcist, PharacistId> : IRepository<Pharmacist, PharmacistId>
{
}