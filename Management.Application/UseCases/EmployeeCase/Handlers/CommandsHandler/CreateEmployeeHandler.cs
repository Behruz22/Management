using Management.Application.Abstractions;
using Management.Application.UseCases.EmployeeCase.Commands;
using Management.Core.Entities;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Handlers.CommandsHandler;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            CompanyId = request.CompanyId,
            UserId = request.UserId,
            Role = request.Role
        };

        await _context.Employees.AddAsync(employee,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
