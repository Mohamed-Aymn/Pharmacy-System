using ManagementService.Types;

namespace ManagementService.Contracts.Medicine.Update;

public record UpdateMedicineRequest(
    string Name,
    string BarCode,
    MedicineType MedicineType
);
