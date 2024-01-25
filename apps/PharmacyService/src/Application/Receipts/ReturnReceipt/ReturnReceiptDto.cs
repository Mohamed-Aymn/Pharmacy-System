using MediatR;
using PharmacyService.Application.Receipts.Common;

namespace PharmacyService.Application.Receipts.ReturnReceipt;

public record ReturnReceiptDto(
    string[] MedicinesId,
    string CashierId
) : IRequest<ReceiptResult>;