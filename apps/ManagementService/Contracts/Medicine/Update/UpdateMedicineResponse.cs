namespace ManagementService.Contracts.Medicine.Update;

public record UpdateMedicineResponse
{
  public string Message { set; get; }
  public UpdateMedicineResponse(string Name)
  {
    Message = $"{Name} Medicine is updated successfully";
  }
};
