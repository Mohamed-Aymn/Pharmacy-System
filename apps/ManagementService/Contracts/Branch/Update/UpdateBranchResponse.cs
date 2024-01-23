namespace ManagementService.Contracts.Branch.Update;

public record UpdateBranchResponse
{
  public string Message { set; get; }
  public UpdateBranchResponse(string Name)
  {
    Message = $"{Name} Branch is updated successfully";
  }
};
