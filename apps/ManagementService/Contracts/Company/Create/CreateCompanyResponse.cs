namespace ManagementService.Contracts.Company.Create;

public record CreateCompanyResponse
{
  public string Message { set; get; }
  public CreateCompanyResponse(string Name)
  {
    Message = $"{Name} Company is created successfully";
  }
};
