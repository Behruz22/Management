using Management.Application.Abstractions;
using Management.Application.UseCases.EmployeeCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.EmployeeCase.Handlers.CommandsHandler;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteEmployeeHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id);

        if (employee != null)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
