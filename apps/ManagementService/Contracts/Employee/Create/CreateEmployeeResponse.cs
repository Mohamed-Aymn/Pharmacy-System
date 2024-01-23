namespace ManagementService.Contracts.Employee.Create;

public record CreateEmployeeResponse
{
  public string Message { set; get; }
  public CreateEmployeeResponse(string Name)
  {
    Message = $"{Name} Employee is created successfully";
  }
};
