using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Application.Receipts.Common;

namespace PharmacyService.Application.Receipts.CreateReceipt;

public record CreateReceiptDto(
    string[] MedicinesId,
    string BranchId,
    string PharmacistId,
    string CashierId
) : IRequest<ReceiptResult>;