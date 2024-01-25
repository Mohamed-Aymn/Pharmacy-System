using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.Create;

public record DispenseMedicineDto(
    BranchId BranchId,
    PharmacistId PharmacistId,
    string[] MedicineIds
) : IRequest<MedicineResult>;