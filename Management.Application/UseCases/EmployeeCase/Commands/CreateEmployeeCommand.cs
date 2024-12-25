using Management.Core.Enums;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Commands;

public class CreateEmployeeCommand : IRequest<bool>
{
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public Role Role { get; set; }
}
