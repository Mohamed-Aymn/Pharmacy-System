using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace BranchService.Application.Medicines.DirectSearch;

public record DirectSearchDto(
    string BarCode
) : IRequest<MedicineResult>;