using ManagementService.Types;
using MediatR;

namespace ManagementService.Contracts.Medicine.Update;

public record UpdateMedicineDTO(
    string Name,
    string BarCode,
    MedicineType MedicineType
) : IRequest<UpdateMedicineResponse>;
