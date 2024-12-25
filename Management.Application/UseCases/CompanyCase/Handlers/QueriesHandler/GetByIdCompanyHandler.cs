
using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.UseCases.CompanyCase.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.CompanyCase.Handlers.QueriesHandler;

public class GetByIdCompanyHandler : IRequestHandler<GetByIdCompanyQuery, CompanyDto>
{
    private readonly IApplicationDbContext _context;

    public GetByIdCompanyHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanyDto> Handle(GetByIdCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == request.Id);


        if (company != null)
        {
            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Email = company.Email,
                Phone = company.Phone,
                CreatedAt = company.CreatedAt,
                UpdatedAt = company.UpdatedAt
            };
        }
        else
        {
            return null;
        }
    }
}
