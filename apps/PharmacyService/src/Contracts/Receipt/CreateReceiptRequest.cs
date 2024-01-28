namespace PharmacyService.Contracts.Receipt;

public record CreateReceiptRequest(
    string[] MedicinesName,
    string BranchId,
    string PharmacistId,
    string CashierId
);