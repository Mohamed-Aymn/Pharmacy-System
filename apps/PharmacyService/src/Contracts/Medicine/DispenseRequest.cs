namespace PharmacyService.Contracts.Medicine;

public record DispsneRequest(
    Guid PharamcistId,
    Guid BranchId,
    string[] MedicineIds
);