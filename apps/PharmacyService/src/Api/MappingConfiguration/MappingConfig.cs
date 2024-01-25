using Mapster;
using PharmacyService.Application.Medicines.Create;
using PharmacyService.Application.Medicines.ReceiveBranchTransfer;
using PharmacyService.Application.Medicines.SendBranchTransfer;
using PharmacyService.Application.Receipts.CreateReceipt;
using PharmacyService.Application.Receipts.ReturnReceipt;
using PharmacyService.Contracts.Medicine;
using PharmacyService.Contracts.Receipt;
using PharmacyService.Domain.SharedKernel.ValueObjects;

namespace PharmacyService.Api.MappingConfiguration;
public class MappingConfig
{
  public static void Configure()
  {
    MedicineObjects();
    ReceiptObjects();
  }

  private static void ReceiptObjects()
  {
    TypeAdapterConfig<CreateReceiptRequest, CreateReceiptDto>.NewConfig()
        .Map(dest => dest.BranchId.Value, src => src.BranchId)
        .Map(dest => dest.PharmacistId.Value, src => src.PharmacistId)
        .Map(dest => dest.CashierId.Value, src => src.CashierId);

    TypeAdapterConfig<ReturnReceiptRequest, ReturnReceiptDto>.NewConfig()
        .Map(dest => dest.CashierId.Value, src => src.CashierId);
  }

  private static void MedicineObjects()
  {
    TypeAdapterConfig<DispsneRequest, DispenseMedicineDto>.NewConfig()
        .Map(dest => dest.BranchId.Value, src => src.BranchId)
        .Map(dest => dest.PharmacistId.Value, src => src.PharmacistId);

    TypeAdapterConfig<ReceiveBranchTransferRequest, ReceiveBranchTransferDto>.NewConfig()
        .Map(dest => dest.PharmacistId.Value, src => src.PharmacistId);

    TypeAdapterConfig<SendBranchTransferRequest, SendBranchTransferDto>.NewConfig()
        .Map(dest => dest.PharmacistId.Value, src => src.PharmacistId)
        .Map(dest => dest.BranchId.Value, src => src.BranchId);
  }
}