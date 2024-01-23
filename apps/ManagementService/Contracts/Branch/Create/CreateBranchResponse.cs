namespace ManagementService.Contracts.Branch.Create;

public record CreateBranchResponse
{
  public string Message { set; get; }
  public CreateBranchResponse(string Name)
  {
    Message = $"{Name} Branch is created successfully";
  }
};
