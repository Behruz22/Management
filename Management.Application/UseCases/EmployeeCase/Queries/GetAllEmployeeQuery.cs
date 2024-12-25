using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Queries;

public class GetAllEmployeeQuery : IRequest<IQueryable<EmployeeDto>>
{
}
