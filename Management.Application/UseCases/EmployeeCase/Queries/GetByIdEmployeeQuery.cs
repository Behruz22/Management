using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Queries;

public class GetByIdEmployeeQuery : IRequest<EmployeeDto>
{
    public int Id { get; set; }
}
