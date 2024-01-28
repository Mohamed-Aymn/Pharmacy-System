using MediatR;
using PharmacyService.Application.Receipts.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Receipts.ReturnReceipt;

public record ReturnReceiptDto(
    string[] MedicinesName,
    CashierId CashierId
) : IRequest<ReceiptResult>;