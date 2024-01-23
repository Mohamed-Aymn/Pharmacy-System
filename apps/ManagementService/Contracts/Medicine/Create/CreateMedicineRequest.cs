using ManagementService.Types;

namespace ManagementService.Contracts.Medicine.Create;

public record CreateMedicineRequest(
    string Name,
    string BarCode,
    MedicineType MedicineType
);