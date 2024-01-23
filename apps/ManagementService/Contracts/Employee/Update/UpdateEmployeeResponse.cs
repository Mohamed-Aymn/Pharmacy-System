namespace ManagementService.Contracts.Employee.Update;

public record UpdateEmployeeResponse
{
  public string Message { set; get; }
  public UpdateEmployeeResponse(string Name)
  {
    Message = $"{Name} Employee is updated successfully";
  }
};
