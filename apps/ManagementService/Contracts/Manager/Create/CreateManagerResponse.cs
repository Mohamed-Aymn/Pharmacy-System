namespace ManagementService.Contracts.Manager.Create;

public record CreateManagerResponse
{
  public string Message { set; get; }
  public CreateManagerResponse(string Name)
  {
    Message = $"{Name} Manager is created successfully";
  }
};
