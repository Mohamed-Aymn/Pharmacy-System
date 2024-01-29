namespace PharmacyService.Application.Medicines.Common.Events;

public record MedicineCreatedEvent(
    string Name,
    string BarCode,
    int MedicineType
);