using Management.Core.Enums;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Commands;

public class UpdateEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public Role Role { get; set; }
}
