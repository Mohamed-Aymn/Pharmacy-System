namespace PharmacyService.Contracts.Receipt;

public record CreateReceiptRequest(
    string[] MedicinesId,
    string BranchId,
    string PharmacistId,
    string CashierId
);