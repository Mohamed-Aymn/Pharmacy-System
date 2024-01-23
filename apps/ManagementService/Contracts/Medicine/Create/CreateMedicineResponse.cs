namespace ManagementService.Contracts.Medicine.Create;

public record CreateMedicineResponse
{
  public string Message { set; get; }
  public CreateMedicineResponse(string Name)
  {
    Message = $"{Name} Medicine is created successfully";
  }
};
