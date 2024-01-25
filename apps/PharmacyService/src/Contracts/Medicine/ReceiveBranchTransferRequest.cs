namespace PharmacyService.Contracts.Medicine;

public record ReceiveBranchTransferRequest(
    string TransferCode,
    Guid PharmacistId
);