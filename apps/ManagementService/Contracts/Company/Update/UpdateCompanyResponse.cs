namespace ManagementService.Contracts.Company.Update;

public record UpdateCompanyResponse
{
  public string Message { set; get; }
  public UpdateCompanyResponse(string Name)
  {
    Message = $"{Name} Company is updated successfully";
  }
};
