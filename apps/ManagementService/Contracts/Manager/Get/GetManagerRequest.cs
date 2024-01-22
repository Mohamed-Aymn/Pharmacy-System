using MediatR;

namespace ManagementService.Contracts.Manager.Get;

public record GetManagerRequest() : IRequest<IEnumerable<GetManagerResponse>>;
