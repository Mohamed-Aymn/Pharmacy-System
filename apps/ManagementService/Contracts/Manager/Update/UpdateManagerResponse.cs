namespace ManagementService.Contracts.Manager.Update;

public record UpdateManagerResponse
{
  public string Message { set; get; }
  public UpdateManagerResponse(string Name)
  {
    Message = $"{Name} Manager is updated successfully";
  }
};
