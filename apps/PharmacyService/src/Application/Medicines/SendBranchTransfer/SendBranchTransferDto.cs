using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.SendBranchTransfer;

public record SendBranchTransferDto(
    PharmacistId PharmacistId,
    BranchId BranchId,
    string[] MedicinesName
) : IRequest<MedicineResult>;