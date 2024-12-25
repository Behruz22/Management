using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.UseCases.EmployeeCase.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.EmployeeCase.Handlers.QueriesHandler;

public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;

    public GetByIdEmployeeHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeDto> Handle(GetByIdEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.AsNoTracking()
                                               .FirstOrDefaultAsync(e => e.Id == request.Id,cancellationToken);

        var user = await _context.Users.AsNoTracking()
                                       .Where(u => u.Id == employee.UserId)
                                       .FirstOrDefaultAsync(cancellationToken);


        var company = await _context.Companies.AsNoTracking()
                                              .Where(c => c.Id == employee.CompanyId)
                                              .FirstOrDefaultAsync(cancellationToken);

        return new EmployeeDto
        {
            Id = request.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CampanyName = company.Name
        };
    }
}
