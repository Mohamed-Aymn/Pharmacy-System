using MediatR;
using PharmacyService.Application.Medicines.Common;

namespace PharmacyService.Application.Medicines.BranchesSearch;

public record BranchesSearchDto(
    string MedicineIds
) : IRequest<MedicineResult>;