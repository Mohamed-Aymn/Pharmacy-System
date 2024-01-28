namespace PharmacyService.Contracts.Medicine;

public record SendBranchTransferRequest(
    string PharmacistId,
    string BranchId,
    string[] MedicinesName
);