namespace PharmacyService.Contracts.Medicine;

public record DispsneRequest(
    Guid PharmacistId,
    Guid BranchId,
    string[] MedicinesName
);