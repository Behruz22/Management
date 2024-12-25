using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.UseCases.CompanyCase.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.CompanyCase.Handlers.QueriesHandler;

public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, IQueryable<CompanyDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCompanyHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<CompanyDto>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
    {
        var companies = _context.Companies.AsNoTracking().Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            Phone = c.Phone,
            Address = c.Address,
            Email = c.Email,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        });

        return companies;
    }
}
