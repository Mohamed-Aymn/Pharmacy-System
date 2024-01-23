using MapsterMapper;
using MediatR;
using ManagementService.Persistence;
using ManagementService.Contracts.Medicine.Get;

namespace ManagementService.ControllersPipelineHandlers.Medicines;

public class GetMedicinesHandler : IRequestHandler<GetMedicinesRequest, IEnumerable<GetMedicinesResponse>>
{
  private readonly IRepository<Models.Medicine, string> _managerRepository;
  private readonly IMapper _mapper;
  public GetMedicinesHandler(IRepository<Models.Medicine, string> managerRepository, IMapper mapper)
  {
    _mapper = mapper;
    _managerRepository = managerRepository;
  }

  public async Task<IEnumerable<GetMedicinesResponse>> Handle(GetMedicinesRequest request, CancellationToken cancellationToken)
  {
    var managers = await _managerRepository.GetAllAsync();
    return managers.Select(manager => _mapper.Map<GetMedicinesResponse>(manager));
  }
}