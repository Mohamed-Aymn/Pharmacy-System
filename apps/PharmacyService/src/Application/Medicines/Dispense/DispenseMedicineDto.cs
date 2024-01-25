using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.Create;

public record DispenseMedicineDto(
    PharmacistId PharmacistId,
    BranchId BranchId,
    string[] MedicinesName
) : IRequest<MedicineResult>;