using ManagementService.Types;
using MediatR;

namespace ManagementService.Contracts.Medicine.Create;

public record CreateMedicineDTO(
    string Name,
    string Concentration,
    string BarCode,
    MedicineType MedicineType
) : IRequest<CreateMedicineResponse>;
