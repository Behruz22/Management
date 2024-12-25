using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Commands;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
}
