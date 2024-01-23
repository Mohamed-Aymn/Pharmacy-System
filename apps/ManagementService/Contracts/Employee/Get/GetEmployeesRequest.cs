using MediatR;

namespace ManagementService.Contracts.Employee.Get;

public record GetEmployeesRequest() : IRequest<IEnumerable<GetEmployeesResponse>>;
