namespace PharmacyService.Contracts.Receipt;

public record ReturnReceiptRequest(
    string[] MedicinesName,
    string CashierId
);