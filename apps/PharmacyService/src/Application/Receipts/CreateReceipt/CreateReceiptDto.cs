using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Application.Receipts.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Receipts.CreateReceipt;

public record CreateReceiptDto(
    string[] MedicinesName,
    BranchId BranchId,
    PharmacistId PharmacistId,
    CashierId CashierId
) : IRequest<ReceiptResult>;