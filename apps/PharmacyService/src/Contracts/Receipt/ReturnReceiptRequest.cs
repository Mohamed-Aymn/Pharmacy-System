namespace PharmacyService.Contracts.Receipt;

public record ReturnReceiptRequest(
    string[] MedicinesIds,
    string CashierId
);