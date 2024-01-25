using MediatR;
using PharmacyService.Application.Medicines.Common;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Application.Medicines.ReceiveBranchTransfer;

public record ReceiveBranchTransferDto(
    string TransferCode,
    PharmacistId PharmacistId
) : IRequest<MedicineResult>;