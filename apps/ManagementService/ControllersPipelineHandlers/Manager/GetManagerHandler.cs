using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Manager.Get;

namespace ManagementService.ControllersPipelineHandlers.Manager;

public class GetManagerHandler : IRequestHandler<GetManagerRequest, IEnumerable<GetManagerResponse>>
{
  private readonly IRepository<Models.Manager, string> _managerRepository;
  private readonly IMapper _mapper;
  public GetManagerHandler(IRepository<Models.Manager, string> managerRepository, IMapper mapper)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public async Task<IEnumerable<GetManagerResponse>> Handle(GetManagerRequest request, CancellationToken cancellationToken)
  {
    // var managers = await _managerRepository.GetAllAsync();
    // return (IEnumerable<GetManagerResponse>)_mapper.Map<GetManagerResponse>(managers);



    var managers = await _managerRepository.GetAllAsync();

    // Map each Manager object to GetManagerResponse
    var response = managers.Select(manager => _mapper.Map<GetManagerResponse>(manager));

    return response;
  }
}