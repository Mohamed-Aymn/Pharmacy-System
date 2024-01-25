using MediatR;
using PharmacyService.Application.Medicines.Common;

namespace BranchService.Application.Medicines.DirectSearch;

public record DirectSearchDto(
    string BarCode
) : IRequest<MedicineResult>;