namespace PharmacyService.Contracts.Medicine;

public record SendBranchTransferRequest(
    string PharamcistId,
    string BranchId,
    string[] MedicinesName
);