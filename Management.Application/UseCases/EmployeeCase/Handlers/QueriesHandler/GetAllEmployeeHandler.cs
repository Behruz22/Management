using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.UseCases.EmployeeCase.Queries;
using Management.Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.EmployeeCase.Handlers.QueriesHandler;

public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IQueryable<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllEmployeeHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<EmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Employees
                            .Join(_context.Companies.AsNoTracking(),
                                    e => e.CompanyId, 
                                    c => c.Id,        
                                   (e, c) => new { Employee = e, Company = c }) 
                            .Join(_context.Users.AsNoTracking(),
                                    ec => ec.Employee.UserId, 
                                    u => u.Id,                
                                    (ec, u) => new EmployeeDto
                                    {
                                        Id = ec.Employee.Id,
                                        CampanyName = ec.Company.Name,
                                        FirstName = u.FirstName,
                                        LastName = u.LastName
                                    });

        return query;
    }
}
