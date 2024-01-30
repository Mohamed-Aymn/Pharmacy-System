namespace SharedKernel.Events;

public record MedicineCreatedEvent(
    string Name,
    string BarCode,
    int MedicineType
);