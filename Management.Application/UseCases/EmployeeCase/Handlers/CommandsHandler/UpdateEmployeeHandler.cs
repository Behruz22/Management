using Management.Application.Abstractions;
using Management.Application.UseCases.EmployeeCase.Commands;
using MediatR;

namespace Management.Application.UseCases.EmployeeCase.Handlers.CommandsHandler;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateEmployeeHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == request.Id);
        if (employee != null)
        {
            employee.UserId = request.UserId;
            employee.CompanyId = request.CompanyId;
            employee.Role = request.Role;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
