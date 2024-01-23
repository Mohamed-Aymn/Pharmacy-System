using ManagementService.Types;

namespace ManagementService.Contracts.Medicine.Get;

public record GetMedicinesResponse(
    string Name,
    string BarCode,
    MedicineType MedicineType
);
