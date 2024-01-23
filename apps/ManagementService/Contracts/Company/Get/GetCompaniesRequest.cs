using MediatR;

namespace ManagementService.Contracts.Company.Get;

public record GetCompaniesRequest() : IRequest<IEnumerable<GetCompaniesResponse>>;
