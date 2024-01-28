using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.Search;

public record SearchDto(
    string MedicineName
) : IRequest<MedicineResult>;